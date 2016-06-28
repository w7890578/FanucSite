using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class HttpMethod
    {
        public static byte RequestByte(string QueryKey, byte DefaultValue)
        {
            byte result = DefaultValue;
            if (System.Web.HttpContext.Current.Request[QueryKey] != null && System.Web.HttpContext.Current.Request[QueryKey].Trim() != "")
            {
                byte.TryParse(System.Web.HttpContext.Current.Request[QueryKey].Trim(), out result);
            }
            return result;
        }
        public static byte RequestByte(string QueryKey, byte DefaultValue, bool ISQueryString)
        {
            byte result = DefaultValue;
            if (ISQueryString)
            {
                if (System.Web.HttpContext.Current.Request.QueryString[QueryKey] != null && System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim() != "")
                {
                    byte.TryParse(System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim(), out result);
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Request.Form[QueryKey] != null && System.Web.HttpContext.Current.Request.Form[QueryKey].Trim() != "")
                {
                    byte.TryParse(System.Web.HttpContext.Current.Request.Form[QueryKey].Trim(), out result);
                }
            }
            return result;
        }
        public static int RequestInt(string QueryKey)
        {
            int result = 0;
            if (System.Web.HttpContext.Current.Request[QueryKey] != null && System.Web.HttpContext.Current.Request[QueryKey].Trim() != "")
            {
                int.TryParse(System.Web.HttpContext.Current.Request[QueryKey].Trim(), out result);
            }
            return result;
        }
        public static int RequestInt(string QueryKey, int DefaultValue)
        {
            int result = DefaultValue;
            int currentResult = 0;
            if (System.Web.HttpContext.Current.Request[QueryKey] != null)
            {
                if (int.TryParse(System.Web.HttpContext.Current.Request[QueryKey].Trim(), out currentResult))
                {
                    result = currentResult;
                }
            }
            return result;
        }
        public static int RequestInt(string QueryKey, int DefaultValue, bool ISQueryString)
        {
            int result = DefaultValue;
            if (ISQueryString)
            {
                if (System.Web.HttpContext.Current.Request.QueryString[QueryKey] != null && System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim() != "")
                {
                    int.TryParse(System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim(), out result);
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Request.Form[QueryKey] != null && System.Web.HttpContext.Current.Request.Form[QueryKey].Trim() != "")
                {
                    int.TryParse(System.Web.HttpContext.Current.Request.Form[QueryKey].Trim(), out result);
                }
            }
            return result;
        }
        public static long RequestLong(string QueryKey, long DefaultValue)
        {
            long result = DefaultValue;
            if (System.Web.HttpContext.Current.Request[QueryKey] != null && System.Web.HttpContext.Current.Request[QueryKey].Trim() != "")
            {
                long.TryParse(System.Web.HttpContext.Current.Request[QueryKey].Trim(), out result);
            }
            return result;
        }
        public static decimal RequestDecimal(string QueryKey, decimal DefaultValue)
        {
            decimal result = DefaultValue;
            if (System.Web.HttpContext.Current.Request[QueryKey] != null && System.Web.HttpContext.Current.Request[QueryKey].Trim() != "")
            {
                decimal.TryParse(System.Web.HttpContext.Current.Request[QueryKey].Trim(), out result);
            }
            return result;
        }
        public static decimal RequestDecimal(string QueryKey, decimal DefaultValue, bool ISQueryString)
        {
            decimal result = DefaultValue;
            if (ISQueryString)
            {
                if (System.Web.HttpContext.Current.Request.QueryString[QueryKey] != null && System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim() != "")
                {
                    decimal.TryParse(System.Web.HttpContext.Current.Request.QueryString[QueryKey].Trim(), out result);
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Request.Form[QueryKey] != null && System.Web.HttpContext.Current.Request.Form[QueryKey].Trim() != "")
                {
                    decimal.TryParse(System.Web.HttpContext.Current.Request.Form[QueryKey].Trim(), out result);
                }
            }
            return result;
        }
        public static string RequestString(string QueryKey)
        {
            string result = "";
            if (System.Web.HttpContext.Current.Request[QueryKey] != null)
            {
                result = System.Web.HttpContext.Current.Request[QueryKey].Trim();

            }
            if (result == string.Empty || result == "/")
            {
                return result;
            }

            return result;
        }

    }
}
