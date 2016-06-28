using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Common
{
    public class HttpRequestHelper
    {
        private CookieContainer _cookieContainer;//cookie

        /// <summary>
        /// cookie
        /// </summary>
        public CookieContainer cookieContainer
        {
            set { this._cookieContainer = value; }
            get { return _cookieContainer; }
        }
        private static string _contentType = "application/x-www-form-urlencoded";
        private static string _accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/x-silverlight, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-silverlight-2-b1, */*";
        private static string _userAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
        public enum encodingType
        {
            DEFAULT,
            GB2312,
            UTF8
        };
        /// <summary>
        /// 转换类型
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private Encoding getED(encodingType dt)
        {
            switch (dt)
            {
                case encodingType.DEFAULT:
                    return Encoding.Default;
                case encodingType.UTF8:
                    return Encoding.UTF8;
                case encodingType.GB2312:
                    return Encoding.GetEncoding("GB2312");

            }
            return Encoding.Default;

        }
        /// <summary>
        /// 获取指定页面的HTML代码（需要cookie）
        /// </summary>
        /// <param name="postData">提交的数据（用抓包工具查看需要提交的数据）</param>
        /// <param name="url">指定的页面地址</param>
        /// <param name="cookieContainer">cookie集合</param>
        /// <returns></returns>
        public string postHTML(string url, CookieContainer cookieContainer, string postData, encodingType dt, ref string responseUrl)
        {
            byte[] byteRequest = Encoding.Default.GetBytes(postData);
            //请求对象
            HttpWebRequest httpWebRequest;
            //创建指定地址request
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            //请求的COOKIE
            httpWebRequest.CookieContainer = cookieContainer;
            //请求的Content-typeHTTP 标头的值
            httpWebRequest.ContentType = _contentType;
            //请求的RefererHTTP 标头的值
            httpWebRequest.Referer = url;
            //请求Accept HTTP 标头值
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Post";

            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            //关闭流
            stream.Close();
            //响应对象
            HttpWebResponse httpWebResponse;
            //得到响应对象
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream streamresponse = httpWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(streamresponse, getED(dt));
            //关闭流
            string html = sr.ReadToEnd();
            sr.Close();
            //关闭流
            streamresponse.Close();

            responseUrl = httpWebResponse.ResponseUri.ToString();
            return html;
        }
        /// <summary>
        /// 获取指定页面的HTML代码（需要cookie）
        /// </summary>
        /// <param name="postData">提交的数据（用抓包工具查看需要提交的数据）</param>
        /// <param name="url">指定的页面地址</param>
        /// <param name="cookieContainer">cookie集合</param>
        /// <returns></returns>
        public string postHTML(string url, string postData, encodingType dt, ref string responseUrl)
        {/*
          try {     res = (HttpWebResponse)req.GetResponse(); }
          catch (WebException ex) {     res = (HttpWebResponse)ex.Response; }
          */
            if (url == "")
            {
                return "";
            }
            byte[] byteRequest = Encoding.Default.GetBytes(postData);
            //请求对象
            HttpWebRequest httpWebRequest;
            //创建指定地址request
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);

            //请求的Content-typeHTTP 标头的值
            httpWebRequest.ContentType = _contentType;
            //请求的RefererHTTP 标头的值
            try
            {
                httpWebRequest.Referer = url;
            }
            catch { }
            //请求Accept HTTP 标头值
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Post";
            httpWebRequest.Timeout = 3000;
            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(byteRequest, 0, byteRequest.Length);
            //关闭流
            stream.Close();
            //响应对象
            HttpWebResponse httpWebResponse;
            string html = string.Empty;
            //得到响应对象
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream streamresponse = httpWebResponse.GetResponseStream();
                StreamReader sr = new StreamReader(streamresponse, getED(dt));
                //关闭流
                html = sr.ReadToEnd();
                sr.Close();
                //关闭流
                streamresponse.Close();
                responseUrl = httpWebResponse.ResponseUri.ToString();
            }
            catch (WebException ex)
            {
                httpWebResponse = (HttpWebResponse)ex.Response;
            }



            return html;



        }

        public string postHTML(string url, CookieContainer cookieContainer, string postData, encodingType dt)
        {
            byte[] byteRequest = Encoding.Default.GetBytes(postData);
            //请求对象
            HttpWebRequest httpWebRequest;
            //创建指定地址request
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            //请求的COOKIE
            httpWebRequest.CookieContainer = cookieContainer;
            //请求的Content-typeHTTP 标头的值
            httpWebRequest.ContentType = _contentType;
            //请求的RefererHTTP 标头的值
            httpWebRequest.Referer = url;
            //请求Accept HTTP 标头值
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Post";
            httpWebRequest.ContentLength = byteRequest.Length;
            Stream stream = Stream.Null;
            try
            {
                stream = httpWebRequest.GetRequestStream();
            }
            catch
            {
                return "request out";
            }
            stream.Write(byteRequest, 0, byteRequest.Length);
            //关闭流
            stream.Close();
            //响应对象
            HttpWebResponse httpWebResponse;
            //得到响应对象
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string responseUrl = httpWebResponse.ResponseUri.ToString();
            return responseUrl;
        }
        /// <summary>
        /// 获取指定页面的HTML代码（需要cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cookieContainer"></param>
        /// <returns></returns>
        public string getHTML(string url, CookieContainer cookieContainer, encodingType dt)
        {
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.ContentType = _contentType;
            httpWebRequest.Referer = url;
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Get";
            HttpWebResponse httpWebResponse;
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream streamresponse = httpWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(streamresponse, getED(dt));
            string html = sr.ReadToEnd();
            sr.Close();//关闭流
            streamresponse.Close();//关闭流
            return html;
        }
        /// <summary>
        /// get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getHTML(string url)
        {
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.ContentType = _contentType;
            httpWebRequest.Referer = url;
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Get";

            HttpWebResponse httpWebResponse;
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream streamresponse = httpWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(streamresponse, Encoding.Default);
            string html = sr.ReadToEnd();
            sr.Close();//关闭流
            streamresponse.Close();//关闭流
            return html;
        }
        /// <summary>
        /// POST
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string postHTML(string url)
        {
            HttpWebRequest httpWebRequest;
            httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.ContentType = _contentType;
            httpWebRequest.Referer = url;
            httpWebRequest.Accept = _accept;
            httpWebRequest.UserAgent = _userAgent;
            httpWebRequest.Method = "Post";

            HttpWebResponse httpWebResponse;
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream streamresponse = httpWebResponse.GetResponseStream();
            StreamReader sr = new StreamReader(streamresponse, Encoding.Default);
            string html = sr.ReadToEnd();
            sr.Close();//关闭流
            streamresponse.Close();//关闭流
            return html;
        }
    }
}
