using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
    public class ExplainBookView : ExplainBook, ViewCreate 
      {
        public PageNation<ExplainBookView> CurrentPage = new PageNation<ExplainBookView>();
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public ExplainBookView ConvertToView(ExplainBook item)
        {
            ExplainBookView view = new ExplainBookView();
            view.ID=item.ID;
            view.BookNumber=item.BookNumber;
            view.BookName=item.BookName;
            view.Version=item.Version;
            view.Language=item.Language;
            view.OneLevelSort=item.OneLevelSort;
            view.TwoLeverSort=item.TwoLeverSort;
            view.DownLoadLink=item.DownLoadLink;
            view.ExtractPwd=item.ExtractPwd;
            view.UnzipPwd=item.UnzipPwd;
            view.IsLoginCheck=item.IsLoginCheck;
            view.Remark=item.Remark;
            view.AccessCount=item.AccessCount;
            view.IsDel=item.IsDel;
            view.IsVisable=item.IsVisable;
            view.CreateTime=item.CreateTime;
            view.UpdateTime=item.UpdateTime;
            return view;
        }
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<ExplainBookView> ConvertToView(List<ExplainBook> resoureList)
        {
            List<ExplainBookView> views = new List<ExplainBookView>();
            foreach (ExplainBook item in resoureList)
            {
                views.Add(ConvertToView(item));
            }
            return views;
        } 
        
        /// <summary>
        /// 获取列表
        /// </summary>
        public void Get_List()
        {
            List<ExplainBook> resultList = new List<ExplainBook>();
            ORM.BLL<ExplainBook>.Query q = ExplainBookBLL.Instance.Where("isdel=0"); 
            
            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(BookNumber))
            {
                q.And("BookNumber like @BookNumber").Parms("%"+BookNumber+"%");
            }
            if (!string.IsNullOrEmpty(BookName))
            {
                q.And("BookName like @BookName").Parms("%"+BookName+"%");
            }
            if (!string.IsNullOrEmpty(Version))
            {
                q.And("Version like @Version").Parms("%"+Version+"%");
            }
            if (!string.IsNullOrEmpty(Language))
            {
                q.And("Language like @Language").Parms("%"+Language+"%");
            }
            if (!string.IsNullOrEmpty(OneLevelSort))
            {
                q.And("OneLevelSort like @OneLevelSort").Parms("%"+OneLevelSort+"%");
            }
            if (!string.IsNullOrEmpty(TwoLeverSort))
            {
                q.And("TwoLeverSort like @TwoLeverSort").Parms("%"+TwoLeverSort+"%");
            }
            if (!string.IsNullOrEmpty(DownLoadLink))
            {
                q.And("DownLoadLink like @DownLoadLink").Parms("%"+DownLoadLink+"%");
            }
            if (!string.IsNullOrEmpty(ExtractPwd))
            {
                q.And("ExtractPwd like @ExtractPwd").Parms("%"+ExtractPwd+"%");
            }
            if (!string.IsNullOrEmpty(UnzipPwd))
            {
                q.And("UnzipPwd like @UnzipPwd").Parms("%"+UnzipPwd+"%");
            }
            if (!string.IsNullOrEmpty(Remark))
            {
                q.And("Remark like @Remark").Parms("%"+Remark+"%");
            }
            if (AccessCount > 0)
            {
                q.And("AccessCount=@AccessCount").Parms(AccessCount);
            }
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }
        
        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            ExplainBookView view = new ExplainBookView();
            List<ExplainBook> list = ExplainBookBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }
        
      }

    public class ExplainBookBLL : BLL<ExplainBook>
    {
		#region 定义
		private static object lockObject = new object();
        protected ExplainBookBLL()
            : base(new ExplainBookDAL())
        {
        }
        private static volatile ExplainBookBLL _instance;
        public static ExplainBookBLL Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
						return _instance ?? (_instance = new ExplainBookBLL());
                    }
                }
                return _instance;
            }
        }
		#endregion
		#region 方法
        #endregion
	}
}
