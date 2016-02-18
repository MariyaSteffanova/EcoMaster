namespace Econom.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute("Default", "{controller}/{action}", new { action = "Index" });
            routes.MapRoute(
                  "Default",
                  "{controller}/{action}/{id}",
                  new { controller = "Home", action = "Index", area = "Public", id = UrlParameter.Optional },
                   new[] { "Econom.Web.Areas.Public.Controllers" }).DataTokens.Add("area", "Public");
        }
    }
}
