namespace Econom.Web.Areas.Public.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class KeyboardController : Controller
    {
        public ActionResult Input()
        {
            return View(string.Empty);
        }

        public ActionResult Find(string barcode)
        {
            return View();
        }
    }
}