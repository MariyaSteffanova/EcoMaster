namespace Econom.Web.Areas.Public.Controllers
{
    using System.Web.Mvc;

    public class IntroController : Controller
    {
        // GET: Public/Intro
        public ActionResult Index()
        {
            return this.View();
        }
    }
}