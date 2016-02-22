namespace Econom.Web.Areas.Private.Controllers
{
    using Infrastructure.BaseControllers;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using Services.Searchers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ViewModels;
    public class KitchenController : BaseMapController
    {
        private readonly IStorageProductsService storageProductsService;
        private readonly IRecipesSearcherService recipesSearcher;

        public KitchenController(IStorageProductsService storageProductsService, IRecipesSearcherService recipesSearcher)
        {
            this.storageProductsService = storageProductsService;
            this.recipesSearcher = recipesSearcher;
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

        [OutputCache(Duration = 60 * 15)]
        public ActionResult GetRecipes(IEnumerable<int> data)
        {
            var result = this.recipesSearcher.SearchRecipes(data)
                .To<RecipeSearchResultViewModel>()
                .ToList(); // TODO: 

            return this.PartialView("_RecipesFound", result);
        }
    }
}