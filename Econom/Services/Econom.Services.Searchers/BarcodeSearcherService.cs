namespace Econom.Services.Searchers
{
    using System.Linq;

    using Contracts;
    using Data.Contracts;
    using Data.TransferModels;
    using ItemMasterProduct = ItemMasterData.Models.Product;

    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        private readonly IRepository<ItemMasterProduct> itemMasterProducts;

        public BarcodeSearcherService(IRepository<ItemMasterProduct> itemMasterProducts)
        {
            this.itemMasterProducts = itemMasterProducts;
        }

        public IQueryable<ProductBase> Search(string barcode)
        {
            // TODO: Search in BG Barcode if culture is BG ??

            return this.itemMasterProducts.All()
                .Where(x => x.Barcode == barcode)
                .Select(x => new ProductBase
                {
                    Barcode = x.Barcode,
                    Description = x.Description
                });

            // TODO: Mapper
            // TODO: ImageService -> get image from url and map to ProductBase
        }
    }
}
