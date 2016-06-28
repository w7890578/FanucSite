using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DataHelper
{
    //public class SqlserverHelper<T> : IData<T>
    //{
    //    internal static DbType GetDbType(Type type, out string sqlType)
    //    {
    //        DbType dbType;
    //        switch (Type.GetTypeCode(type))
    //        {
    //            case TypeCode.String: sqlType = "nvarchar2"; dbType = DbType.String; break;
    //            case TypeCode.Int32: sqlType = "number"; dbType = DbType.Int32; break;
    //            case TypeCode.Single: sqlType = "number"; dbType = DbType.Single; break;
    //            case TypeCode.Double: sqlType = "number"; dbType = DbType.Double; break;
    //            case TypeCode.DateTime: sqlType = "date"; dbType = DbType.DateTime2; break;
    //            case TypeCode.Int16: sqlType = "number"; dbType = DbType.Int16; break;
    //            case TypeCode.Int64: sqlType = "number"; dbType = DbType.Int64; break;
    //            case TypeCode.UInt32: sqlType = "number"; dbType = DbType.UInt32; break;
    //            case TypeCode.UInt16: sqlType = "number"; dbType = DbType.UInt16; break;
    //            case TypeCode.UInt64: sqlType = "number"; dbType = DbType.UInt64; break;
    //            //case TypeCode.Char:
    //            default: sqlType = "nvarchar2"; dbType = DbType.String; break;
    //        }
    //        return dbType;
    //    }

    //    public static List<T> GetListAll()
    //    {
    //        Type type = typeof(T);
    //        List<T> resultlist = new List<T>();
    //        Database db = DatabaseFactory.CreateDatabase("Fanuc_Reader");
    //        DbCommand cmd = db.GetSqlStringCommand("select * from [" + type.Name + "]");
    //        IDataReader iread = db.ExecuteReader(cmd);
    //        while (iread.Read())
    //        {
    //            T model = (T)Assembly.Load(type.Namespace).CreateInstance(type.Namespace + "." + type.Name);

    //            foreach (var item in model.GetType().GetProperties())
    //            {
    //                item.SetValue(model, iread[item.Name], null);
    //            }
    //            resultlist.Add(model);
    //        }
    //        return resultlist;
    //    }

    //    public static bool Insert(T entity)
    //    {

    //        Type type = entity.GetType();
    //        Database db = DatabaseFactory.CreateDatabase("Fanuc_Reader");
    //        DbCommand cmd = db.GetSqlStringCommand("select 1");
    //        StringBuilder sbpar = new StringBuilder(" values(");
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendFormat("Insert into [{0}] (", type.Name);
    //        List<DbParameter> dbpara = new List<DbParameter>();
    //        for (int i = 0; i < type.GetProperties().Count(); i++)
    //        {
    //            if (i != 0)
    //            {
    //                sb.Append(",");
    //                sbpar.Append(",");
    //            }
    //            string propertiesName = type.GetProperties()[i].Name;
    //            sb.Append(propertiesName);
    //            sbpar.Append("@" + propertiesName);
    //            object value = type.GetProperties()[i].GetValue(entity, null);
    //            string typenames = string.Empty;
    //            db.AddInParameter(cmd, "@" + propertiesName, GetDbType(type.GetProperties()[i].PropertyType, out   typenames), value);
    //        }
    //        sb.Append(")").Append(sbpar.Append(")"));
    //        cmd.CommandText = sb.ToString();
    //        return db.ExecuteNonQuery(cmd) > 0;
    //    }
    //}

    public class DataOp<T>
    {


        public static bool InSert(T entity)
        {
            //return SqlserverHelper.Insert(entity.GetType());
            //Database db = DatabaseFactory.CreateDatabase("Fanuc_Reader");
            ////IDbCommand cmd = new DbCommand();
            //DbCommand cmd = db.GetSqlStringCommand("select 1");
            //var type = entity.GetType();
            //StringBuilder sb = new StringBuilder();
            //sb.Append("Insert into ");
            ////type.GetProperties()[0].PropertyType.Name
            //foreach (var item in type.GetProperties())
            //{

            //}

            return false;
        }
    }
}
