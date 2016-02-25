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
    public class ProductsManagerController : BaseMapController
    {
        private readonly IProductService products;

        public ProductsManagerController(IProductService products)
        {
            this.products = products;
        }

        // GET: Admin/ProductsManager
        public ActionResult Index()
        {
            var viewModel = this.products.GetAll().To<ProductViewModel>();

            return this.View(viewModel);
        }

        public ActionResult Get([DataSourceRequest]DataSourceRequest request)
        {
            var viewModel = this.products.GetAll().To<ProductViewModel>();

            return Json(viewModel.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var user = this.Mapper.Map<Product>(model);

                this.products.Update(user);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}