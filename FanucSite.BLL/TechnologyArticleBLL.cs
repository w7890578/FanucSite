using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
    public class TechnologyArticleView : TechnologyArticle
    {
        public PageNation<TechnologyArticleView> CurrentPage = new PageNation<TechnologyArticleView>();

        public string CreateTimeStr
        {
            get
            {
                if (CreateTime == null || CreateTime == Convert.ToDateTime("1900-01-01"))
                {
                    return "--";
                }
                else
                {
                    return CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
        public string ContentStr
        {
            get
            {
                return FunLayer.Str.Cut(Content, 30, "...");
            }
        }
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public TechnologyArticleView ConvertToView(TechnologyArticle item)
        {
            TechnologyArticleView view = new TechnologyArticleView();
            view.ID = item.ID;
            view.Title = item.Title;
            view.Content = item.Content;
            view.Source = item.Source;
            view.Classify = item.Classify;
            view.AccessCount = item.AccessCount;
            view.GoodComment = item.GoodComment;
            view.BadComment = item.BadComment;
            view.IsDel = item.IsDel;
            view.IsVisable = item.IsVisable;
            view.CreateTime = item.CreateTime;
            view.UpdateTime = item.UpdateTime;
            return view;
        }

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<TechnologyArticleView> ConvertToView(List<TechnologyArticle> resoureList)
        {
            List<TechnologyArticleView> views = new List<TechnologyArticleView>();
            foreach (TechnologyArticle item in resoureList)
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
            List<TechnologyArticle> resultList = new List<TechnologyArticle>();
            ORM.BLL<TechnologyArticle>.Query q = TechnologyArticleBLL.Instance.Where("isdel=0");

            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(Title))
            {
                q.And("Title like @Title").Parms("%"+Title+"%");
            }
            if (!string.IsNullOrEmpty(Content))
            {
                q.And("Content like @Content").Parms("%"+Content+"%");
            }
            if (!string.IsNullOrEmpty(Source))
            {
                q.And("Source like @Source").Parms("%"+Source+"%");
            }
            if (!string.IsNullOrEmpty(Classify))
            {
                q.And("Classify like @Classify").Parms("%"+Classify+"%");
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
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }

        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            TechnologyArticleView view = new TechnologyArticleView();
            List<TechnologyArticle> list = TechnologyArticleBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }

    }

    public class TechnologyArticleBLL : BLL<TechnologyArticle>
    {
        #region 定义
        private static object lockObject = new object();
        protected TechnologyArticleBLL()
            : base(new TechnologyArticleDAL())
        {
        }
        private static volatile TechnologyArticleBLL _instance;
        public static TechnologyArticleBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new TechnologyArticleBLL());
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
