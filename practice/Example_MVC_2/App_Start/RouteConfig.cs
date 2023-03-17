using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Example_MVC_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "NewView", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                    name: "NewView",
                    url:"{controller}/{action}/{masv}/{name}/{age}/{date}/{address}"
                );
        }
    }
}
