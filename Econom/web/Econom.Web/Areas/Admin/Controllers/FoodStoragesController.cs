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
    public class FoodStoragesController : BaseMapController
    {
        private readonly IHomeStorageService foodStorages;

        public FoodStoragesController(IHomeStorageService foodStorages)
        {
            this.foodStorages = foodStorages;
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            var viewModel = this.foodStorages.GetAll().To<FoodStorageViewModel>();

            return this.View(viewModel);
        }

        public ActionResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var viewModel = this.foodStorages.GetAll().To<FoodStorageViewModel>();

            return Json(viewModel.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, FoodStorageViewModel model)
        {
            this.foodStorages.Delete(model.ID);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}