namespace Econom.Services.Data.Contracts
{
    using System.Linq;

    using BarcodeData.Models;

    public interface IBarcodeService
    {
        IQueryable<Product> GetByBarcode(string barcode);
    }
}
