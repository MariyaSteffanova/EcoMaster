namespace Econom.Web.Areas.Private.Controllers
{
    using System.Web.Mvc;

    using Data.Models;
    using Econom.Services.Data.Contracts;
    using Econom.Web.Areas.Private.InputModels;
    using Infrastructure.BaseControllers;
    using Infrastructure.Filters;

    using Microsoft.AspNet.Identity;
    using Common;
    using System;
    [Authorize]
    public class HomeStorageController : BaseMapController
    {
        private readonly IUserService users;
        private readonly IHomeStorageService storages;

        public HomeStorageController(IUserService userService, IHomeStorageService storages)
        {
            this.users = userService;
            this.storages = storages;
        }

        [HomeStorageOwnerWrapper]
        public ActionResult Index() // TODO: Take it from current user
        {
            return this.View();
        }

        [HomeStorageOwnerWrapper]
        public ActionResult AddProduct(int id) // TODO: Move in another Controller
        {
            var username = this.User.Identity.Name;

            return this.View("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new HomeStorageInputModel());
        }

        [HttpPost]
        public ActionResult Create(HomeStorageInputModel model)
        {
            // TODO: Attribute
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            if (this.users.IsOwner(this.User.Identity.GetUserId()))
            {
                // TODO: Notification
                return this.RedirectToAction("Index");
            }

            var dbModel = this.Mapper.Map<HomeStorage>(model);
            var created = this.storages.Create(dbModel, this.User.Identity.GetUserId());
            model = this.Mapper.Map<HomeStorageInputModel>(created);

            ViewBag.Created = true;

            return this.View(model);
        }

        public ActionResult PostCreate()
        {
            var pendingProductID = this.Session[GlobalConstants.PendingHomestorageCreationProductId];
            if (pendingProductID != null)
            {
                return this.RedirectToAction("AddProduct", new { id = Convert.ToInt32(pendingProductID) });
            }

            return this.RedirectToAction("Index");
        }
    }
}