namespace Econom.Services.Logic
{
    using System.Linq;
    using Searchers.Contracts;
    using Data.Contracts;
    using Econom.Data.Models;
    using Contracts;

    public class ProductProcessorService : IProductProcessorService
    {
        private readonly IBarcodeSearcherService barcodeSearcherService;
        private readonly IProductService productDataService;
        private readonly ICategoryResolverService categoryResolver;

        public ProductProcessorService(IBarcodeSearcherService barcodeService, IProductService productDataService, ICategoryResolverService categoryResolver)
        {
            this.barcodeSearcherService = barcodeService;
            this.productDataService = productDataService;
            this.categoryResolver = categoryResolver;
        }

        public IQueryable<Product> ProcessByBarcode(string barcode)
        {
            var result = this.barcodeSearcherService
                 .Search(barcode)
                 .Select(x => new Product()
                 {
                     Name = x.Description,
                     Barcode = x.Barcode,
                     Category = this.categoryResolver.Resolve(new string[] { x.CategoryGS1, x.CategoryName }),
                     Image = x.Image,
                     ImageUrl = x.ImageUrl
                 });

            this.productDataService.InsertMany(result); // TODO: Resolve category

            return result.AsQueryable();
        }
    }
}
