using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
    public class PartView : Part
    {
        public PageNation<PartView> CurrentPage = new PageNation<PartView>();

        public List<Part_Children> Part_ChildrenList = new List<Part_Children>();

        public List<Part_Pic> Part_PicList = new List<Part_Pic>();

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public PartView ConvertToView(Part item)
        {
            PartView view = new PartView();
            view.ID = item.ID;
            view.MaterialNumber = item.MaterialNumber;
            view.MaterialDescription = item.MaterialDescription;
            view.OldModel = item.OldModel;
            view.OneLevelSort = item.OneLevelSort;
            view.TwoLevelSort = item.TwoLevelSort;
            view.Name = item.Name;
            view.Explain = item.Explain;
            view.IsStop = item.IsStop;
            view.Price = item.Price;
            view.AccessCount = item.AccessCount;
            view.GoodComment = item.GoodComment;
            view.BadComment = item.BadComment;
            view.CommentCount = item.CommentCount;
            view.IsDel = item.IsDel;
            view.IsVisable = item.IsVisable;
            view.CreateTime = item.CreateTime;
            view.UpdateTime = item.UpdateTime;
            view.Part_PicList = Part_PicBLL.Instance.Where("PartID=@PartID and IsDel=0").Parms(view.ID).ListAll();
            view.Part_ChildrenList = Part_ChildrenBLL.Instance.Where("PartID=@PartID and IsDel=0").Parms(view.ID).ListAll();
            return view;
        }

        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<PartView> ConvertToView(List<Part> resoureList)
        {
            
            List<PartView> views = new List<PartView>();
            foreach (Part item in resoureList)
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
            List<Part> resultList = new List<Part>();
            ORM.BLL<Part>.Query q = PartBLL.Instance.Where("isdel=0");

            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%" + ID + "%");
            }
            if (!string.IsNullOrEmpty(MaterialNumber))
            {
                q.And("MaterialNumber like @MaterialNumber ").Parms("%" + MaterialNumber + "%");
            }
            if (!string.IsNullOrEmpty(MaterialDescription))
            {
                q.And("MaterialDescription like @MaterialDescription").Parms("%" + MaterialDescription + "%");
            }
            if (!string.IsNullOrEmpty(OldModel))
            {
                q.And("OldModel like @OldModel").Parms("%" + OldModel + "%");
            }
            if (!string.IsNullOrEmpty(OneLevelSort))
            {
                q.And("OneLevelSort like @OneLevelSort").Parms("%" + OneLevelSort + "%");
            }
            if (!string.IsNullOrEmpty(TwoLevelSort))
            {
                q.And("TwoLevelSort like @TwoLevelSort").Parms("%" + TwoLevelSort + "%");
            }
            if (!string.IsNullOrEmpty(Name))
            {
                q.And("Name like @Name").Parms("%" + Name + "%");
            }
            if (!string.IsNullOrEmpty(Explain))
            {
                q.And("Explain like @Explain").Parms("%" + Explain + "%");
            }
            if (IsStop > 0)
            {
                q.And("IsStop=@IsStop").Parms(IsStop);
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
            PartView view = new PartView();
            List<Part> list = PartBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }

    }

    public class PartBLL : BLL<Part>
    {
        #region 定义
        private static object lockObject = new object();
        protected PartBLL()
            : base(new PartDAL())
        {
        }
        private static volatile PartBLL _instance;
        public static PartBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new PartBLL());
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
