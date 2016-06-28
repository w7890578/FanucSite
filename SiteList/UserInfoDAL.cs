using System;
using System.Collections.Generic;
using System.Text;
using ORM; 
using Company.Models;

namespace DAL
{
    public class UserInfoDAL : DAL<UserInfo>
    {
        public UserInfoDAL()
        {
            initDb(ORMDAL.GetNormal, ORMDAL.GetRead, ORMDAL.GetWrite);
        }
    }
}