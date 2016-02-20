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
    using System.Collections.Generic;
    using Common.Extensions;
    using System.Collections.ObjectModel;
    using Mappers;
    using Data.Models;
    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        private readonly ICollection<IProvider> providers = new Collection<IProvider>();

        public BarcodeSearcherService(IItemMasterProvider itemMasterProvider)
        {
            this.providers.Add(itemMasterProvider);
        }

        public IQueryable<Product> Search(string barcode)
        {
            // TODO: Foreach all rpoviders and get list of ProductBAse

            // TODO: Save in MyDb - without EcoInfo - the claculator need location from HomeStorage for this step

            // TODO: Search in BG Barcode if culture is BG ??

            var products = new List<Product>();

            this.providers
                 .ForEach(x =>
                 {
                     products.AddRange(x.GetByBarcode(barcode).Select(ProductMap.FromBaseProduct));
                 });

            return products.AsQueryable();

        }

    }
}
