using Econom.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Private.Controllers
{
    public class HomeStorageController : UserController
    {
        public HomeStorageController(IUserService userService)
                : base(userService)
        {

        }

        // GET: Private/HomeStorage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct(int id)
        {
            var username = this.User.Identity.Name;
            return View();
        }
    }
}