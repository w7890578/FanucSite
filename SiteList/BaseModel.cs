using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SiteList
{
    /// <summary>
    /// 定义抽象基类
    /// </summary>
    public abstract class BaseModel<T>
    {
        protected int PageIndex = 1;
        protected int PageCount = 0;
        protected int PageSize = 0;
        /// <summary>
        /// 网址
        /// </summary>
        protected string SiteUrl { get; set; }

        ///// <summary>
        ///// 创建实例
        ///// </summary>
        ///// <returns></returns>
        //public abstract T CreateInstance();

        /// <summary>
        /// 去除很多带“\”的符号，例：回车符
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string TrimOther(string source)
        {
            source = Regex.Replace(source, "<script[^>]*?>.*?</script>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, "<noscript[^>]*?>.*?</noscript>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, "<style[^>]*?>.*?</style>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, "\n|\t|\r", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, ">\\s+<", "><", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, "\\s+<", "<", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            source = Regex.Replace(source, ">\\s+", ">", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            return source.Replace(@"\""", "\"")
                .Replace("  ", " ").Replace("&nbsp;","") ; 

        }


    }
}
