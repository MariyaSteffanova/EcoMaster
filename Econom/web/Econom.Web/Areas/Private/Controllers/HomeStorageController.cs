namespace Econom.Web.Areas.Private.Controllers
{
    using System.Web.Mvc;

    using Econom.Services.Data.Contracts;
    using Econom.Web.Areas.Private.InputModels;
    using Econom.Web.Infrastructure.Filters;

    [Authorize]
    public class HomeStorageController : Controller
    {
        private readonly IUserService users;

        public HomeStorageController(IUserService userService)
        {
            this.users = userService;
        }

        [HomeStorageOwner]
        public ActionResult Index()
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
                       
            return this.View();
        }
    }
}