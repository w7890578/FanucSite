using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FanucSite.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
         
            HttpContext.Trace.IsEnabled = true;
            HttpContext.Trace.Warn("sdfsdf");
            HttpContext.Trace.Write("sdfsdf");
            return View();

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Server()
        {
            return View();
        }
        public ActionResult Rrczp()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}
