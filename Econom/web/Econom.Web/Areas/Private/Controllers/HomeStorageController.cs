using Econom.Data;
using Econom.Data.Contracts;
using Econom.Data.Models;
using Econom.Services.Data;
using Econom.Services.Data.Contracts;
using Econom.Web.Controllers;
using Econom.Web.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Private.Controllers
{
    [Authorize]
    public class HomeStorageController : Controller
    {
        private readonly IUserService users;

        public HomeStorageController(IUserService userService)
        {
            this.users = userService;
        }

        // GET: Private/HomeStorage
        public ActionResult Index()
        {
            return View();
        }

        [HomeStorageOwner]
        public ActionResult AddProduct(int id)
        {
            var username = this.User.Identity.Name;
        
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}