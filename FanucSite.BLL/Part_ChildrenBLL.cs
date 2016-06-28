using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
      public class Part_ChildrenView:Part_Children
      {
        public PageNation<Part_ChildrenView> CurrentPage = new PageNation<Part_ChildrenView>();
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public Part_ChildrenView ConvertToView(Part_Children item)
        {
            Part_ChildrenView view = new Part_ChildrenView();
            view.ID=item.ID;
            view.PartID=item.PartID;
            view.ChildMaterialNumber=item.ChildMaterialNumber;
            view.Remark=item.Remark;
            view.IsDel=item.IsDel;
            view.IsVisable=item.IsVisable;
            view.CreateTime=item.CreateTime;
            view.UpdateTime=item.UpdateTime;
            return view;
        }
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<Part_ChildrenView> ConvertToView(List<Part_Children> resoureList)
        {
            List<Part_ChildrenView> views = new List<Part_ChildrenView>();
            foreach (Part_Children item in resoureList)
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
            List<Part_Children> resultList = new List<Part_Children>();
            ORM.BLL<Part_Children>.Query q = Part_ChildrenBLL.Instance.Where("isdel=0"); 
            
            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(PartID))
            {
                q.And("PartID like @PartID").Parms("%"+PartID+"%");
            }
            if (!string.IsNullOrEmpty(ChildMaterialNumber))
            {
                q.And("ChildMaterialNumber like @ChildMaterialNumber").Parms("%"+ChildMaterialNumber+"%");
            }
            if (!string.IsNullOrEmpty(Remark))
            {
                q.And("Remark like @Remark").Parms("%"+Remark+"%");
            }
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }
        
        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            Part_ChildrenView view = new Part_ChildrenView();
            List<Part_Children> list = Part_ChildrenBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }
        
      }

    public class Part_ChildrenBLL : BLL<Part_Children>
    {
		#region 定义
		private static object lockObject = new object();
        protected Part_ChildrenBLL()
            : base(new Part_ChildrenDAL())
        {
        }
        private static volatile Part_ChildrenBLL _instance;
        public static Part_ChildrenBLL Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
						return _instance ?? (_instance = new Part_ChildrenBLL());
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
