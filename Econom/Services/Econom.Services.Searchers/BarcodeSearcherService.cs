namespace Econom.Services.Searchers
{
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using Data.TransferModels;
    using Services.Logic.Contracts;
    using ItemMasterProduct = ItemMasterData.Models.Product;
    using ItemMasterData.Data;
    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        private readonly IRepository<IItemMasterDbContext, ItemMasterProduct> itemMasterProducts;
        private readonly IImageDownloaderService imageDownloader;
        private readonly IImageProcessorService imageProcessor;

        public BarcodeSearcherService(IRepository<IItemMasterDbContext, ItemMasterProduct> itemMasterProducts, IImageDownloaderService imageDownloader, IImageProcessorService imageProcessor)
        {
            this.itemMasterProducts = itemMasterProducts;
            this.imageDownloader = imageDownloader;
            this.imageProcessor = imageProcessor; // TODO: Remove?
        }

        public IQueryable<ProductBase> Search(string barcode)
        {
            // TODO: Foreach all rpoviders and get list of ProductBAse

            // TODO: Save in MyDb - without EcoInfo - the claculator need location from HomeStorage for this step

            // TODO: Search in BG Barcode if culture is BG ??
            var products = this.itemMasterProducts.All()
               .Where(x => x.Barcode == barcode)
               .Select(x => new ProductBase
               {
                   Id = x.Id,
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
