namespace Econom.Web
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Workaround for registration flow causing wrong mapping
            RouteBase defaultArea = routes[0];
            routes.RemoveAt(0);
            routes.Add(defaultArea);
            routes.MapRoute(
                  name: "Default",
                  url: "Nana/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
