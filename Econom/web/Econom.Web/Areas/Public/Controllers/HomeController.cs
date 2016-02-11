namespace Econom.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    using Econom.Services.Data.Contracts;
    using Web.Controllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}