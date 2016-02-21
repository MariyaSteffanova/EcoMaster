namespace Econom.Services.Providers.Contracts
{
    using System.Collections.Generic;
    using TransferModels;

    public interface IProductProvider
    {
        IEnumerable<ProductBase> GetByBarcode(string barcode);
    }
}
