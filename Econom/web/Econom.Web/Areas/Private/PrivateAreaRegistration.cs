namespace Econom.Web.Areas.Private
{
    using System.Web.Mvc;

    public class PrivateAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Private";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              name: "Private_default",
                url: "Private/{controller}/{action}",
                defaults: new { controller = "HomeStorage", action = "Index" });
        }
    }
}