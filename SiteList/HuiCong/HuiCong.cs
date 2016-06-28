using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Company.Models;

namespace SiteList
{
    public partial class HuiCong : BaseModel<HuiCong>
    {
        //创建信号灯
        public ManualResetEvent eventX = new ManualResetEvent(false);
        protected int iCount = 0;
        /// <summary>
        /// 主函数
        /// </summary>
        public void Grab()
        {
            SiteUrl = "http://s.hc360.com/?mc=enterprise&ee={0}&z=%D6%D0%B9%FA%3A%B1%B1%BE%A9";
            string pageHtml = TrimOther(new Common.HttpRequestHelper().getHTML(string.Format(SiteUrl, 1)));
            if (Regex.IsMatch(pageHtml, "(?<=<span class=\"total\">共)\\d+(?=页</span>)"))
            {
                pageHtml = Regex.Match(pageHtml, "(?<=<span class=\"total\">共)\\d+(?=页</span>)").Value;
                PageCount = FunLayer.Transform.Int(pageHtml, 0);
            }
            for (int i = 1; i <= PageCount; i++)
            {
                //循环每一页将线程排入线程池
                //将函数排入队列，线程池将自动分配线程执行
                ThreadPool.QueueUserWorkItem(new WaitCallback(Search), i);
            }
        }
        
        /// <summary>
        /// 每一页数据的分析
        /// </summary>
        /// <param name="index"></param>
        private void Search(object index)
        {
            string htmlStr = TrimOther(new Common.HttpRequestHelper().getHTML(string.Format(SiteUrl, index)));
            MatchCollection mc = Regex.Matches(htmlStr, "(?<=<!-- col S -->).+?(?=<!-- bottom_info bm-info -->)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (var item in mc)
            {
                if (Regex.IsMatch(item.ToString(), "href=\"(?'link'.*?)\"\\s?onclick", RegexOptions.IgnoreCase | RegexOptions.Singleline))
                {
                    string companyLink = Regex.Match(item.ToString(), "href=\"(?'link'.*?)\"\\s?onclick", RegexOptions.IgnoreCase).Groups["link"].Value;
                    GetDeatil(companyLink);
                }
            }
            //多线程并行执行情况下，执行原子操作(此处是在某一正在进行的线程执行完上面的代码后执行原子操作，标志当前线程完成任务。)
            Interlocked.Increment(ref iCount);
            //完成的线程数和页数一致时发出结束信号，标志本线程池中线程已全部执行结束。 
            if (iCount == PageCount)
            {
                Console.WriteLine("发出结束信号!");
                eventX.Set();
            }
        }
        /// <summary>
        /// 具体某个公司信息的匹配
        /// </summary>
        /// <param name="url"></param>
        private void GetDeatil(string url)
        {
            string htmlStr = TrimOther(new Common.HttpRequestHelper().getHTML(url + "shop/show.html"));
            UserInfo user = new UserInfo();
            user.CompanyName = Regex.Match(htmlStr, "<h1[^>]+?>(?'CompanyName'.+?)</h1>", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups["CompanyName"].Value.Trim();

            string pattern = string.Concat(
                 @"<h5\s?[^>]+?>\s?"
                , @"<li\s?title=""(?'name'[^>]+?)"">\s?"
                , @"<span\s?title=""(?'ContactName'[^>]+?)"">([^<]+?)</span>\s?"
                , @"<span\s?title=""(?'ContactPost'[^>]+?)"">([^<]+?)</span>\s?"
                , @"</li>\s?"
                , @"</h5>\s?"
                , @"(?'textlist'(<h5><li\s+title=""[^>]+?"">[^>]+?</li></h5>)+)");
            if (Regex.IsMatch(htmlStr, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline))
            {
                Match mc = Regex.Match(htmlStr, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                user.ContactName = mc.Groups["ContactName"].Value;
                user.ContactPost = mc.Groups["ContactPost"].Value;
                htmlStr = mc.Groups["textlist"].Value;
                if (Regex.IsMatch(htmlStr, "title=\".+?\"", RegexOptions.IgnoreCase | RegexOptions.Singleline))
                {
                    MatchCollection mcdetail = Regex.Matches(htmlStr, "title=\"(?'text'.+?)\"", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                    foreach (var item in mcdetail)
                    {
                        string itemtext = item.ToString().Replace("title=", "").Replace("\"", "").Trim();
                        string itemname = itemtext.Substring(0, itemtext.IndexOf("：") + 1);
                        switch (itemname)
                        {
                            case "电话：":
                                user.FixedTelephone = itemtext.Replace(itemname, "");
                                break;
                            case "手机：":
                                user.Mobile = itemtext.Replace(itemname, "");
                                break;
                            case "传真：":
                                user.Fax = itemtext.Replace(itemname, "");
                                break;
                            default: ;
                                break;
                        }
                    }
                }

                Console.WriteLine("=========" + user.CompanyName + "===========");
                Console.WriteLine(user.ContactName + "|" + user.ContactPost + "|" + user.Mobile);

            }

        }



        private static object lockObject = new object();
        private static volatile HuiCong _instance;
        public static HuiCong Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new HuiCong());
                    }
                }
                return _instance;
            }
        } 

    }
}
