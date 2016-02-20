namespace Econom.Services.Searchers.Contracts
{
    using System.Linq;

    using Econom.Data.TransferModels;
    using Data.Models;

    public interface IBarcodeSearcherService
    {
        IQueryable<Product> Search(string barcode);
    }
}
