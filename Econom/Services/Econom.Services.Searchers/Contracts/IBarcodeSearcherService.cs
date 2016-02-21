namespace Econom.Services.Searchers.Contracts
{
    using System.Linq;
    using TransferModels;

    public interface IBarcodeSearcherService
    {
        IQueryable<ProductBase> Search(string barcode);
    }
}
