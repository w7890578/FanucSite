using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace FanucSite.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            ////filterContext.Exception;//记录错误信息
            //// 当自定义显示错误 mode = On，显示友好错误页面
            //if (filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    filterContext.ExceptionHandled = true;
            //    this.View("Error").ExecuteResult(this.ControllerContext);
            //}
            //获取异常信息，入库保存
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息
            string Url = HttpContext.Request.RawUrl;//错误发生地址
            WriteErrorTxt(Message, Url);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面
        }

        private void WriteErrorTxt(string msg, string url)
        {
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = dateNow + ".txt";
            string filePath = Server.MapPath(string.Concat("/Text/Error/", fileName));
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(dateNow + " 错误信息:" + msg + "  URL:" + url);
                sw.Close();
                fs.Close();
            }
            else
            {
                StreamWriter sw = System.IO.File.AppendText(filePath);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
