using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Models;
using DAL;
using ORM;

namespace SiteList
{
    public class UserInfoBLL : BLL<UserInfo>
    {
        #region 定义
        private static object lockObject = new object();
        protected UserInfoBLL()
            : base(new UserInfoDAL())
        {
        }
        private static volatile UserInfoBLL _instance;
        public static UserInfoBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        return _instance ?? (_instance = new UserInfoBLL());
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
