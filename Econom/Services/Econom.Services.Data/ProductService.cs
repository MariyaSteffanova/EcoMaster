namespace Econom.Services.Data
{
    using Contracts;
    using Econom.Data.Contracts;
    using Econom.Data.Models;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> products;
        private readonly IBarcodeService barcodeService;

        public ProductService(IRepository<Product> products, IBarcodeService barcodeService)
        {
            this.products = products;
            this.barcodeService = barcodeService;
        }

        public IQueryable<Product> SearchByBarcode(string barcode)
        {
            return this.products.All()
                .Where(x => x.Barcode == barcode)
                .Select(x => x);
        }

        public IQueryable<Product> SearchByName(string name)
        {
            return this.products.All()
                .Where(x => x.Name == name)
                .Select(x => x);
        }
    }
}
