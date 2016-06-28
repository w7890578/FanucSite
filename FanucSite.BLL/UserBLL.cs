using System;
using System.Collections.Generic;
using System.Text;
using ORM;

using FanucSite.Models;
using FanucSite.DAL;

namespace FanucSite.BLL
{
    public class UserView : User
    {
        public PageNation<UserView> CurrentPage = new PageNation<UserView>();
        public string RoleName
        {
            get
            {
                if (Role > 0)
                {
                    return ((RoleEnum)Role).ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string AuditTimeStr
        {
            get
            {
                if (AuditTime == null || AuditTime == Convert.ToDateTime("1900-01-01"))
                {
                    return "--";
                }
                else
                {
                    return AuditTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
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


        /// <summary>
        /// 转换为视图对象
        /// </summary>
        public UserView ConvertToView(User item)
        {
            UserView view = new UserView();
            view.ID = item.ID;
            view.CompanyName = item.CompanyName;
            view.Post = item.Post;
            view.FullName = item.FullName;
            view.Email = item.Email;
            view.Nickname = item.Nickname;
            view.Phone = item.Phone;
            view.PassWord = item.PassWord;
            view.IsDel = item.IsDel;
            view.IsVisable = item.IsVisable;
            view.CreateTime = item.CreateTime;
            view.UpdateTime = item.UpdateTime;
            view.AuditStatus = item.AuditStatus;
            view.AuditTime = item.AuditTime;
            view.Role = item.Role;
            view.Remark = item.Remark;
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
                q.And("ID like @ID").Parms("%"+ID+"%");
            }
            if (!string.IsNullOrEmpty(CompanyName))
            {
                q.And("CompanyName like @CompanyName").Parms("%"+CompanyName+"%");
            }
            if (!string.IsNullOrEmpty(Post))
            {
                q.And("Post like @Post").Parms("%"+Post+"%");
            }
            if (!string.IsNullOrEmpty(FullName))
            {
                q.And("FullName like @FullName").Parms("%"+FullName+"%");
            }
            if (!string.IsNullOrEmpty(Email))
            {
                q.And("Email like @Email").Parms("%"+Email+"%");
            }
            if (!string.IsNullOrEmpty(Nickname))
            {
                q.And("Nickname like @Nickname").Parms("%"+Nickname+"%");
            }
            if (!string.IsNullOrEmpty(Phone))
            {
                q.And("Phone like @Phone").Parms("%"+Phone+"%");
            }
            if (!string.IsNullOrEmpty(PassWord))
            {
                q.And("PassWord like @PassWord").Parms("%"+PassWord+"%");
            }
            if (AuditStatus > 0)
            {
                q.And("AuditStatus=@AuditStatus").Parms(AuditStatus);
            }
            if (Role > 0)
            {
                q.And("Role=@Role").Parms(Role);
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
