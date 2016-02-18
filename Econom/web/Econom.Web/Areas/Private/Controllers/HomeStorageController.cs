namespace Econom.Web.Areas.Private.Controllers
{
    using System.Web.Mvc;

    using Data.Models;
    using Econom.Services.Data.Contracts;
    using Econom.Web.Areas.Private.InputModels;
    using Infrastructure.BaseControllers;
    using Infrastructure.Filters;

    using Microsoft.AspNet.Identity;

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

        [HomeStorageOwner]
        public ActionResult Index(int id)
        {
            return this.View();
        }

        [HomeStorageOwner]
        public ActionResult AddProduct(int id)
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
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var dbModel = this.Mapper.Map<HomeStorage>(model);
            var created = this.storages.Create(dbModel, this.User.Identity.GetUserId());
            model = this.Mapper.Map<HomeStorageInputModel>(created);

            ViewBag.Created = true;

            return this.View(model);
        }
    }
}