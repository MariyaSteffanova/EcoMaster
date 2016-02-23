namespace Econom.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Searchers.Contracts;
    using ViewModels.Products;
    using Infrastructure.BaseControllers;
    using Services.Data.Contracts;
    using Services.Logic.Contracts;
    using Infrastructure.Filters;
    public class KeyboardController : BaseController
    {
        private IProductProcessorService productProcessorService;

        public KeyboardController(IProductProcessorService productProcessorService)
        {
            this.productProcessorService = productProcessorService;
        }

      //  [OutputCache(Duration = 60 * 15)]
        public ActionResult Input()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return this.View(string.Empty);
        }

        [SearchModeTracker]
        public ActionResult Find(string barcode)
        {
            var result = this.productProcessorService.ProcessByBarcode(barcode);

            // TODO: Mapper
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