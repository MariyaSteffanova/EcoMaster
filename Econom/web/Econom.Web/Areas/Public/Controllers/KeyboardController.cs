namespace Econom.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Searchers.Contracts;
    using ViewModels.Products;
    using Web.Controllers;

    public class KeyboardController : BaseController
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
                                    Id = p.Id,
                                    Barcode = p.Barcode,
                                    Description = p.Description,
                                    ImageUrl = p.ImageUrl
                                })
                                .ToList();

            return View("Found", result);
        }
    }
}