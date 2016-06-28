using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataHelper
{
    public interface IData<T>
    {
        bool Insert(T entity);
        List<T> GetListAll();
    }
    public abstract class AbstractFactory<T>
    {
        public static IData<T> GetData()
        {
            //s的值以后从Web.config动态获取
            //把s赋值为:TestReflection.EnglishName,将显示英文名
            string s = "TestReflection.ChineseName";
            IData<T> name = (IData<T>)Assembly.Load("TestReflection").CreateInstance(s);
            return name;
        }
        //public abstract bool Insert(T entity);
    }
}
