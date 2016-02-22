using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Private.Controllers
{
    public class SearchController : Controller
    {
        // GET: Public/Search
        public ActionResult Index()
        {
            return this.View();
        }
    }
}