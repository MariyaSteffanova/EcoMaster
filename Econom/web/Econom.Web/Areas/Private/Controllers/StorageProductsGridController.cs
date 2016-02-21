namespace Econom.Web.Areas.Private.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Econom.Data.Models;
    using Econom.Services.Data.Contracts;
    using Econom.Web.Infrastructure.BaseControllers;
    using Microsoft.AspNet.Identity;
    using Econom.Web.Areas.Private.ViewModels;
    using Econom.Web.Infrastructure.Mapping;
    using Common.Extensions;
    public class StorageProductsGridController : BaseMapController
    {
        private readonly IStorageProductsService storageProducts;

        public StorageProductsGridController(IStorageProductsService storageProducts)
        {
            this.storageProducts = storageProducts;
        }

        public ActionResult Index()
        {
            var viewModel = this.storageProducts
                        .All(this.User.Identity.GetUserId())
                        .To<StorageProductViewModel>()
                        .ToList();

            return this.PartialView("_Index", viewModel);
        }

        public ActionResult Get([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<StorageProduct> storageproducts = this.storageProducts.All(this.User.Identity.GetUserId());

            var viewModel = storageproducts.To<StorageProductViewModel>().ToList();

            return Json(viewModel.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request,StorageProductViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                this.storageProducts.Update(model.ID, model.Quantity);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, StorageProductViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {

                this.storageProducts.Delete(model.ID);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
    }
}
