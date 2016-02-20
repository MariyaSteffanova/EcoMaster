namespace Econom.Services.Providers
{
    using System.Collections.Generic;
    using Econom.Data.TransferModels;
    using Econom.Services.Providers.Contracts;
    using Econom.Data.Contracts;
    using ItemMasterData.Data;
    using ItemMasterProduct = ItemMasterData.Models.Product;
    using System.Linq;

    class ItemMasterProvider : IProvider
    {
        private readonly IRepository<IItemMasterDbContext, ItemMasterProduct> itemMasterDb;

        public ItemMasterProvider(IRepository<IItemMasterDbContext, ItemMasterProduct> itemMasterDb)
        {
            this.itemMasterDb = itemMasterDb;
        }

        public IEnumerable<ProductBase> GetByBarcode(string barcode)
        {
            var products = this.itemMasterDb.All()
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

            return products;
        }
    }
}
