using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;
using System.Text.RegularExpressions;

namespace FanucSite.BLL
{
    public class AlarmInfoView : AlarmInfo
    {
        public PageNation<AlarmInfoView> CurrentPage = new PageNation<AlarmInfoView>();

        public string ExcludeAdviceStr
        {
            get
            {
                return FunLayer.Str.Cut(ExcludeAdvice, 30, "...");
            }
        }

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public AlarmInfoView ConvertToView(AlarmInfo item)
        {
            AlarmInfoView view = new AlarmInfoView();
            view.ID = item.ID;
            view.AlarmType = item.AlarmType;
            view.AlarmNumber = item.AlarmNumber;
            view.AlarmMeaning = item.AlarmMeaning;
            view.BrieflyNotes = item.BrieflyNotes;
            view.ExcludeAdvice = item.ExcludeAdvice;
            view.ApplicableSystem = item.ApplicableSystem;
            view.ImgUrl = item.ImgUrl;
            view.AccessCount = item.AccessCount;
            view.GoodComment = item.GoodComment;
            view.BadComment = item.BadComment;
            view.CommentCount = item.CommentCount;
            view.IsDel = item.IsDel;
            view.IsVisable = item.IsVisable;
            view.CreateTime = item.CreateTime;
            view.UpdateTime = item.UpdateTime;
            return view;
        }

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<AlarmInfoView> ConvertToView(List<AlarmInfo> resoureList)
        {
            List<AlarmInfoView> views = new List<AlarmInfoView>();
            foreach (AlarmInfo item in resoureList)
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
            List<AlarmInfo> resultList = new List<AlarmInfo>();
            ORM.BLL<AlarmInfo>.Query q = AlarmInfoBLL.Instance.Where("isdel=0");

            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(AlarmType))
            {
                q.And("AlarmType like @AlarmType").Parms("%"+AlarmType+"%");
            }
            if (!string.IsNullOrEmpty(AlarmNumber))
            {
                string tempStr = "(upper(AlarmNumber) like '%" + AlarmNumber.ToUpper() + "%'";
                if (Regex.IsMatch(AlarmNumber, "[A-Za-z]+")) //里面有字母
                {
                    string temp = Regex.Match(AlarmNumber, "[A-Za-z]+").Value;
                    tempStr += " or " + "upper(AlarmNumber) like '%" + temp.ToUpper() + "%'";
                }
                if (Regex.IsMatch(AlarmNumber, @"\d+"))//里面有数字
                {
                    string temp = Regex.Match(AlarmNumber, @"\d+").Value;
                    tempStr += " or " + "AlarmNumber like '%" + temp + "%'";
                }
                tempStr += ")";
                q.And(tempStr);

            }
            if (!string.IsNullOrEmpty(AlarmMeaning))
            {
                q.And("AlarmMeaning like @AlarmMeaning").Parms("%"+AlarmMeaning+"%");
            }
            if (!string.IsNullOrEmpty(BrieflyNotes))
            {
                q.And("BrieflyNotes like @BrieflyNotes").Parms("%"+BrieflyNotes+"%");
            }
            if (!string.IsNullOrEmpty(ExcludeAdvice))
            {
                q.And("ExcludeAdvice like @ExcludeAdvice").Parms("%"+ExcludeAdvice+"%");
            }
            if (!string.IsNullOrEmpty(ApplicableSystem))
            {
                q.And("ApplicableSystem like @ApplicableSystem").Parms("%"+ApplicableSystem+"%");
            }
            if (!string.IsNullOrEmpty(ImgUrl))
            {
                q.And("ImgUrl like @ImgUrl").Parms("%"+ImgUrl+"%");
            }
            if (AccessCount > 0)
            {
                q.And("AccessCount=@AccessCount").Parms(AccessCount);
            }
            if (GoodComment > 0)
            {
                q.And("GoodComment=@GoodComment").Parms(GoodComment);
            }
            if (BadComment > 0)
            {
                q.And("BadComment=@BadComment").Parms(BadComment);
            }
            if (CommentCount > 0)
            {
                q.And("CommentCount=@CommentCount").Parms(CommentCount);
            }
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }

        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            AlarmInfoView view = new AlarmInfoView();
            List<AlarmInfo> list = AlarmInfoBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }

    }

    public class AlarmInfoBLL : BLL<AlarmInfo>
    {
        #region 定义
        private static object lockObject = new object();
        protected AlarmInfoBLL()
            : base(new AlarmInfoDAL())
        {
        }
        private static volatile AlarmInfoBLL _instance;
        public static AlarmInfoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new AlarmInfoBLL());
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
