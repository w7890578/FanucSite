using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FanucSite.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "PartQuery",
               url: "Part/Query",
               defaults: new { controller = "Part", action = "Query" }
           );
            routes.MapRoute(
                name: "Part",
                 url: "Part.html_{id}_{name}",
                 defaults: new { controller = "Part", action = "Index" },
                 constraints: new { id = @"[\d]*",name=@"[\w]*" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            //        routes.MapRoute(
            //"Default",
            //"{controller}/{action}/{id}",
            //new { controller = "Home", action = "Index", id = "" },
            //new { id = @"[\d]*" } //id必须为数字
            //); 

        }
    }
}