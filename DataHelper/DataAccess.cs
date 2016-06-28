using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataHelper
{
    public class DataAccess
    {
        public static IModel<User> CreateUser()
        {
            //string ClassName = AssemblyName + "." + db + "User";
            // return (Service.IUser)Assembly.Load(AssemblyName).CreateInstance(ClassName);
            return (IModel<User>)Assembly.Load("DataHelper").CreateInstance("User");
        }
    }
}
