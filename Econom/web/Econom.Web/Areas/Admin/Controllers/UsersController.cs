using Econom.Data.Models;
using Econom.Services.Data.Contracts;
using Econom.Web.Areas.Admin.ViewModels;
using Econom.Web.Infrastructure.BaseControllers;
using Econom.Web.Infrastructure.Mapping;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseMapController
    {
        private readonly IUserService users;

        public UsersController(IUserService users)
        {
            this.users = users;
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            var viewModel = this.users.GetAll().To<UserViewModel>();

            return this.View(viewModel);
        }

        public ActionResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var viewModel = this.users.GetAll().To<UserViewModel>();

            return Json(viewModel.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var user = this.Mapper.Map<User>(model);
                if (user.HomeStorage != null && user.HomeStorage.Location != null)
                {
                    user.HomeStorage.Location.Country = model.Country;
                    user.HomeStorage.Location.Town = model.Town;
                }
                this.users.Update(user);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}