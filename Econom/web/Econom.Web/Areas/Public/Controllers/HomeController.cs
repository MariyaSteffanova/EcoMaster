namespace Econom.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.BaseControllers;

    public class HomeController : BaseController
    {
        // TODO: Cache without user
        public ActionResult Index()
        {
            return this.View();
        }

        [OutputCache(Duration = 60 * 15)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        [OutputCache(Duration = 60 * 15)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}