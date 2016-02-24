using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View("NotFound");
        }

        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}