namespace Econom.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Searchers.Contracts;
    using ViewModels.Products;

    public class KeyboardController : Controller
    {
        private readonly IBarcodeSearcherService barcodeSercher;

        public KeyboardController(IBarcodeSearcherService barcodeSercher)
        {
            this.barcodeSercher = barcodeSercher;
        }

        public ActionResult Input()
        {
            return View(string.Empty);
        }

        public ActionResult Find(string barcode)
        {
            var result = this.barcodeSercher
                                .Search(barcode)
                                .Select(p => new ProductBaseViewModel
                                {
                                    Barcode = p.Barcode,
                                    Description = p.Description,
                                    ImageUrl = p.ImageUrl
                                })
                                .ToList();

            return View("Found", result);
        }
    }
}