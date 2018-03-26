using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Summit
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                //url: "{controller}/{action}/{region}/{program}",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
                //, region = "INDIA", program = "ITDP"
            );
        }
    }
}
