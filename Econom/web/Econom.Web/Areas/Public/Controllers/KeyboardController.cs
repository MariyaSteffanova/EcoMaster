namespace Econom.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Searchers.Contracts;
    using ViewModels.Products;
    using Infrastructure.BaseControllers;
    using Services.Data.Contracts;

    public class KeyboardController : BaseController
    {
        private readonly IProductService productService;
        private readonly IBarcodeSearcherService barcodeSercher;

        public KeyboardController(IBarcodeSearcherService barcodeSercher, IProductService productService)
        {
            this.barcodeSercher = barcodeSercher;
            this.productService = productService;
        }

        public ActionResult Input()
        {
            return this.View(string.Empty);
        }

        public ActionResult Find(string barcode)
        {
            var result = this.barcodeSercher
                                .Search(barcode);
          

            var viewmodel = result
                                .Select(p => new ProductBaseViewModel
                                {
                                    Id = p.ID,
                                    Barcode = p.Barcode,
                                    Description = p.Name,
                                    ImageUrl = p.ImageUrl
                                })
                                .ToList();

            return this.View("Found", viewmodel);
        }
    }
}