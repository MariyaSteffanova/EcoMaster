using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Econom.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //  routes.MapRoute("Default", "{controller}/{action}", new { action = "Index" });

            routes.MapRoute(
                  "Default",
                  "{controller}/{action}/{id}",
                  new { controller = "Home", action = "Index", area = "Public", id = UrlParameter.Optional },
                   new[] { "Econom.Web.Areas.Public.Controllers" }
              ).DataTokens.Add("area", "Public");



            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new
            //    {
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }
            //);

            //routes.MapRoute(
            //     "CatchRoot", "",
            //     new { controller = "Home", action = "Index" }
            //    )
            //    .DataTokens.Add("area", "Public");

        }
    }
}
