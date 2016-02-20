namespace Econom.Services.Data.Contracts
{
    using System.Linq;

    using BarcodeData.Models;

    public interface IBarcodeService // TODO: old, remove
    {
        IQueryable<Product> GetByBarcode(string barcode);
    }
}
