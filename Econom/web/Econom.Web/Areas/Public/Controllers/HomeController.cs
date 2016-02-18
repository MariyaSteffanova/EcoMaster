﻿namespace Econom.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.BaseControllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}