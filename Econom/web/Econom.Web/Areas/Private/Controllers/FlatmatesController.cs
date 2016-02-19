namespace Econom.Web.Areas.Private.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Econom.Services.Data.Contracts;
    using Econom.Web.Areas.Private.ViewModels;
    using Infrastructure.BaseControllers;
    using Infrastructure.Mapping;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    public class FlatmatesController : BaseMapController
    {
        private readonly IUserService userService;
        private readonly IHomeStorageService storages;

        public FlatmatesController(IUserService userService, IHomeStorageService storages)
        {
            this.userService = userService;
            this.storages = storages;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Get(ICollection<string> emails)
        {
            var users = this.userService.GetByEmails(emails)
                .To<FlatmateViewModel>()
                .ToList();

            return this.PartialView("_FlatmatesGridView", users);
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<FlatmateViewModel> flatmates)
        {
            var users = this.userService.GetByEmails(flatmates.Select(x => x.Email).ToList());
            this.storages.
            return Json(flatmates.ToList().ToDataSourceResult(request, ModelState));
        }
    }
}