namespace Econom.Services.Providers.Contracts
{
    using Data.TransferModels;
    using System.Collections.Generic;

    public interface IProductProvider
    {
        IEnumerable<ProductBase> GetByBarcode(string barcode);
    }
}
