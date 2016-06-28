using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
      public class UserView:User
      {
        public PageNation<UserView> CurrentPage = new PageNation<UserView>();
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public UserView ConvertToView(User item)
        {
            UserView view = new UserView();
            view.ID=item.ID;
            view.CompanyName=item.CompanyName;
            view.Post=item.Post;
            view.FullName=item.FullName;
            view.Email=item.Email;
            view.Nickname=item.Nickname;
            view.Phone=item.Phone;
            view.PassWord=item.PassWord;
            view.IsDel=item.IsDel;
            view.IsVisable=item.IsVisable;
            view.CreateTime=item.CreateTime;
            view.UpdateTime=item.UpdateTime;
            view.AuditStatus=item.AuditStatus;
            return view;
        }
        
        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public List<UserView> ConvertToView(List<User> resoureList)
        {
            List<UserView> views = new List<UserView>();
            foreach (User item in resoureList)
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
            List<User> resultList = new List<User>();
            ORM.BLL<User>.Query q = UserBLL.Instance.Where("isdel=0"); 
            
            if (!string.IsNullOrEmpty(ID))
            {
                q.And("ID=@ID").Parms(ID);
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                q.And("CompanyName like '%" + CompanyName + "%'");
            }
            if (!string.IsNullOrEmpty(Post))
            {
                q.And("Post like '%" + Post + "%'");
            }
            if (!string.IsNullOrEmpty(FullName))
            {
                q.And("FullName like '%" + FullName + "%'");
            }
            if (!string.IsNullOrEmpty(Email))
            {
                q.And("Email like '%" + Email + "%'");
            }
            if (!string.IsNullOrEmpty(Nickname))
            {
                q.And("Nickname like '%" + Nickname + "%'");
            }
            if (!string.IsNullOrEmpty(Phone))
            {
                q.And("Phone like '%" + Phone + "%'");
            }
            if (!string.IsNullOrEmpty(PassWord))
            {
                q.And("PassWord like '%" + PassWord + "%'");
            }
            if (AuditStatus > 0)
            {
                q.And("AuditStatus=@AuditStatus").Parms(AuditStatus);
            }
            CurrentPage.total = q.List0(resultList, CurrentPage.PageIndex, CurrentPage.PageSize);
            CurrentPage.rows = ConvertToView(resultList);
        }
        
        /// <summary>
        /// 获取明细
        /// </summary>
        public void Get_Detail()
        {
            UserView view = new UserView();
            List<User> list = UserBLL.Instance.Where("ID=@ID and IsDel=0").Parms(ID).ListAll();
            if (list.Count > 0)
            {
                view = ConvertToView(list[0]);
            }
            CurrentPage.Detail = view;
        }
        
      }

    public class UserBLL : BLL<User>
    {
		#region 定义
		private static object lockObject = new object();
        protected UserBLL()
            : base(new UserDAL())
        {
        }
        private static volatile UserBLL _instance;
        public static UserBLL Instance
        {
            get 
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
						return _instance ?? (_instance = new UserBLL());
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
