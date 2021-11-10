using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LC.ClientApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "Currency",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index" }
            //);
            routes.MapRoute(
                name: "Persons",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persons", action = "Index"}
            );
            routes.MapRoute(
                name: "Deposits",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Deposits", action = "Index" }
            );
            routes.MapRoute(
                name: "Loans",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Loans", action = "Index" }
            );
            routes.MapRoute(
                name: "Guarantors",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Guarantors", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
