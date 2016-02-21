namespace Econom.Web.Areas.Private.Controllers
{
    using Infrastructure.BaseControllers;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ViewModels;
    public class KitchenController : BaseMapController
    {
        private IStorageProductsService storageProductsService;

        public KitchenController(IStorageProductsService storageProductsService)
        {
            this.storageProductsService = storageProductsService;
        }

        // GET: Private/Kitchen
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var viewModels = this.storageProductsService
                .All(this.User.Identity.GetUserId())
                .To<StorageProductViewModel>()
                .ToList();

            return this.PartialView("_List", viewModels);
        }

        public ActionResult GetList([DataSourceRequest]DataSourceRequest request)
        {
            var viewModels = this.storageProductsService
               .All(this.User.Identity.GetUserId())
               .To<StorageProductViewModel>()
               .ToList();

            return Json(viewModels.ToDataSourceResult(request, this.ModelState), JsonRequestBehavior.AllowGet);
        }

     
        public ActionResult GetRecipes(IEnumerable<int> data)
        {
            return this.Json(new { Message = "yep" }, JsonRequestBehavior.AllowGet);
        }
    }
}