﻿namespace Econom.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Searchers.Contracts;
    using ViewModels.Products;
    using Infrastructure.BaseControllers;
    using Services.Data.Contracts;
    using Services.Logic.Contracts;

    public class KeyboardController : BaseController
    {
        private IProductProcesorService productProcessorService;

        public KeyboardController(IProductProcesorService productProcessorService)
        {
            this.productProcessorService = productProcessorService;
        }

        public ActionResult Input()
        {
            return this.View(string.Empty);
        }

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