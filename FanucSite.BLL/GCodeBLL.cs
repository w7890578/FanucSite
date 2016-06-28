using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
    public class GCodeView : GCode
    {
        public PageNation<GCodeView> CurrentPage = new PageNation<GCodeView>();

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
        public GCodeView ConvertToView(GCode item)
        {
            GCodeView view = new GCodeView();
            view.ID=item.ID;
            view.CodeNumber=item.CodeNumber;
            view.FunctionDescription=item.FunctionDescription;
            view.Content=item.Content;
            view.Remark=item.Remark;
            view.GoodComment=item.GoodComment;
            view.BadComment=item.BadComment;
            view.CommentCount=item.CommentCount;
            view.AccessCount=item.AccessCount;
            view.IsDel=item.IsDel;
            view.IsVisable=item.IsVisable;
            view.CreateTime=item.CreateTime;
            view.UpdateTime=item.UpdateTime;
            view.Type = item.Type;
            return view;
        }

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<GCodeView> ConvertToView(List<GCode> resoureList)
        {
            List<GCodeView> views = new List<GCodeView>();
            foreach (GCode item in resoureList)
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
            List<GCode> resultList = new List<GCode>();
            ORM.BLL<GCode>.Query q = GCodeBLL.Instance.Where("isdel=0");

            if (Type > 0)
            {
                q.And("Type=@Type").Parms(Type);
            }
            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(CodeNumber))
            {
                q.And("CodeNumber like @CodeNumber").Parms("%"+CodeNumber+"%");
            }
            if (!string.IsNullOrEmpty(FunctionDescription))
            {
                q.And("FunctionDescription like @FunctionDescription").Parms("%"+FunctionDescription+"%");
            }
            if (!string.IsNullOrEmpty(Content))
            {
                q.And("Content like @Content").Parms("%"+Content+"%");
            }
            if (!string.IsNullOrEmpty(Remark))
            {
                q.And("Remark like @Remark").Parms("%"+Remark+"%");
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
            GCodeView view = new GCodeView();
            List<GCode> list = GCodeBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }

    }

    public class GCodeBLL : BLL<GCode>
    {
        #region 定义
        private static object lockObject = new object();
        protected GCodeBLL()
            : base(new GCodeDAL())
        {
        }
        private static volatile GCodeBLL _instance;
        public static GCodeBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new GCodeBLL());
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
