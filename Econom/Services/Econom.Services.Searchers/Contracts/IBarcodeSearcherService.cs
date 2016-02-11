namespace Econom.Services.Searchers.Contracts
{
    using System.Linq;

    using Econom.Data.TransferModels;

    public interface IBarcodeSearcherService
    {
        IQueryable<ProductBase> Search(string barcode);
    }
}
