﻿namespace Econom.Web.Areas.Public
{
    using System.Web.Mvc;

    public class PublicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Public";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Public_default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new[] { "Econom.Web.Areas.Public.Controllers" });
        }
    }
}