namespace Econom.Services.Searchers
{
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using Data.TransferModels;
    using Services.Logic.Contracts;
    using ItemMasterProduct = ItemMasterData.Models.Product;
    using ItemMasterData.Data;
    using Services.Providers.Contracts;

    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        // private readonly IRepository<IItemMasterDbContext, ItemMasterProduct> itemMasterProducts;
        private readonly IItemMasterProvider itemMasterProvider;
        private readonly IImageDownloaderService imageDownloader;
        private readonly IImageProcessorService imageProcessor;

        public BarcodeSearcherService(IItemMasterProvider itemMasterProvider, IImageDownloaderService imageDownloader, IImageProcessorService imageProcessor)
        {
            this.itemMasterProvider = itemMasterProvider;
            this.imageDownloader = imageDownloader;
            this.imageProcessor = imageProcessor; // TODO: Remove?
        }

        public IQueryable<ProductBase> Search(string barcode)
        {
            // TODO: Foreach all rpoviders and get list of ProductBAse

            // TODO: Save in MyDb - without EcoInfo - the claculator need location from HomeStorage for this step

            // TODO: Search in BG Barcode if culture is BG ??

            var products = this.itemMasterProvider
                .GetByBarcode(barcode);

            return products.AsQueryable();

        }

    }
}
