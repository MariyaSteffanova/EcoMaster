namespace Econom.Services.Logic.Contracts
{
    using System;
    using System.Linq;
    using Searchers.Contracts;
    using Data.Contracts;
    using Econom.Data.Models;
    using Mappers;
    public class ProductProcessorService : IProductProcesorService
    {
        private readonly IBarcodeSearcherService barcodeSearcherService;
        private readonly IProductService productDataService;

        public ProductProcessorService(IBarcodeSearcherService barcodeService, IProductService productDataService)
        {
            this.barcodeSearcherService = barcodeService;
            this.productDataService = productDataService;
        }

        public IQueryable<Product> ProcessByBarcode(string barcode)
        {
            var result = this.barcodeSearcherService
                 .Search(barcode)
                 .Select(ProductMap.FromBaseProduct);

           // this.productDataService.InsertMany(result); // TODO: Resolve category
        
            return result.AsQueryable();
        }
    }
}
