using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataHelper
{
    public interface IModel<T>
    {
        bool Insert(T model);
    }
    //public abstract class AbstractFactory<T>
    //{
    //    public T GetModel(string className)
    //    {

    //        var entity = (T)Assembly.Load("DataHelper").CreateInstance("DataHelper.User");
    //        Type type = entity.GetType();
    //        //type.GetProperties();
    //        //type.
    //        return entity;
    //    }

    //}
}
