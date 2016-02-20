namespace Econom.Web.Areas.Private.Controllers
{
    using Econom.Services.Data.Contracts;
    using Econom.Web.Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;

    public class StorageProductsController : Controller
    {
        private IStorageProductsService storageProductsService;

        public StorageProductsController(IStorageProductsService storageProductsService)
        {
            this.storageProductsService = storageProductsService;
        }

        // GET: Private/StorageProducts
        public ActionResult Index()
        {
            return View();
        }

        [HomeStorageOwnerWrapper]
        public ActionResult AddProduct(int id) // TODO: Move in another Controller
        {
            this.storageProductsService
                 .Add(id, this.User.Identity.GetUserId());

            return this.RedirectToAction("Input", "Keyboard");
        }

    }
}