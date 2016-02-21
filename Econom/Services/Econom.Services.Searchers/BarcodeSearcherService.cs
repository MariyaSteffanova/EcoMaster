namespace Econom.Services.Searchers
{
    using System.Linq;

    using Contracts;
    using Services.Providers.Contracts;
    using System.Collections.Generic;
    using Common.Extensions;
    using System.Collections.ObjectModel;
    using TransferModels;
    public class BarcodeSearcherService : IBarcodeSearcherService
    {
        private readonly ICollection<IProductProvider> providers = new Collection<IProductProvider>();

        public BarcodeSearcherService(IItemMasterProvider itemMasterProvider)
        {
            this.providers.Add(itemMasterProvider);
        }

        public IQueryable<ProductBase> Search(string barcode)
        {
            // TODO: Foreach all rpoviders and get list of ProductBAse

            // TODO: Save in MyDb - without EcoInfo - the claculator need location from HomeStorage for this step

            // TODO: Search in BG Barcode if culture is BG ??

            var products = new List<ProductBase>();

            this.providers
                 .ForEach(x =>
                 {
                     products.AddRange(x.GetByBarcode(barcode));
                 });

            return products.AsQueryable();

        }

    }
}
