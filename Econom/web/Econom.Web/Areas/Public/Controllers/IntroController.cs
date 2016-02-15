using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Public.Controllers
{
    public class IntroController : Controller
    {
        // GET: Public/Intro
        public ActionResult Index()
        {
            return View();
        }
    }
}