namespace Econom.Services.Searchers
{
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using Data.TransferModels;
    using Services.Logic.Contracts;
    using ItemMasterProduct = ItemMasterData.Models.Product;

    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        private readonly IRepository<ItemMasterProduct> itemMasterProducts;
        private readonly IImageDownloaderService imageDownloader;
        private readonly IImageProcessorService imageProcessor;

        public BarcodeSearcherService(IRepository<ItemMasterProduct> itemMasterProducts, IImageDownloaderService imageDownloader, IImageProcessorService imageProcessor)
        {
            this.itemMasterProducts = itemMasterProducts;
            this.imageDownloader = imageDownloader;
            this.imageProcessor = imageProcessor; // TODO: Remove?
        }

        public IQueryable<ProductBase> Search(string barcode)
        {
            // TODO: Search in BG Barcode if culture is BG ??
            var products = this.itemMasterProducts.All()
               .Where(x => x.Barcode == barcode)
               .Select(x => new ProductBase
               {
                   Barcode = x.Barcode,
                   Description = x.Description,
                   ImageUrl = x.Images
                            .Where(img => img.Url != null)
                            .Select(img => img.Url)
                            .FirstOrDefault()
               })
               .ToList();

            return products.AsQueryable();

        }

    }
}
