namespace Econom.Services.Data
{
    using System.Linq;

    using BarcodeData.Models;

    using Econom.Data.Contracts;
    using Contracts;

    public class BarcodeService : IBarcodeService
    {
        private readonly IRepository<UPC> barcodes;

        public BarcodeService(IRepository<UPC> barcodes)
        {
            this.barcodes = barcodes;
        }

        public IQueryable<Product> GetByBarcode(string barcode)
        {
            return this.barcodes.All()
                                .Where(x => x.Barcode == barcode)
                                .Select(x => x.Product);
        }
    }
}
