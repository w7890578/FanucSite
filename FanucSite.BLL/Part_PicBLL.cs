using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
      public class Part_PicView:Part_Pic
      {
        public PageNation<Part_PicView> CurrentPage = new PageNation<Part_PicView>();
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public Part_PicView ConvertToView(Part_Pic item)
        {
            Part_PicView view = new Part_PicView();
            view.ID=item.ID;
            view.IsDel=item.IsDel;
            view.IsVisable=item.IsVisable;
            view.CreateTime=item.CreateTime;
            view.UpdateTime=item.UpdateTime;
            view.PartID=item.PartID;
            view.ImgUrl=item.ImgUrl;
            view.ImgDescription=item.ImgDescription;
            return view;
        }
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<Part_PicView> ConvertToView(List<Part_Pic> resoureList)
        {
            List<Part_PicView> views = new List<Part_PicView>();
            foreach (Part_Pic item in resoureList)
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
            List<Part_Pic> resultList = new List<Part_Pic>();
            ORM.BLL<Part_Pic>.Query q = Part_PicBLL.Instance.Where("isdel=0"); 
            
            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(PartID))
            {
                q.And("PartID like @PartID").Parms("%"+PartID+"%");
            }
            if (!string.IsNullOrEmpty(ImgUrl))
            {
                q.And("ImgUrl like @ImgUrl").Parms("%"+ImgUrl+"%");
            }
            if (!string.IsNullOrEmpty(ImgDescription))
            {
                q.And("ImgDescription like @ImgDescription").Parms("%"+ImgDescription+"%");
            }
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }
        
        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            Part_PicView view = new Part_PicView();
            List<Part_Pic> list = Part_PicBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }
        
      }

    public class Part_PicBLL : BLL<Part_Pic>
    {
		#region 定义
		private static object lockObject = new object();
        protected Part_PicBLL()
            : base(new Part_PicDAL())
        {
        }
        private static volatile Part_PicBLL _instance;
        public static Part_PicBLL Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
						return _instance ?? (_instance = new Part_PicBLL());
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
