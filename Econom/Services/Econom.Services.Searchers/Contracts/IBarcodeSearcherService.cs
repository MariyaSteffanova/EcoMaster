namespace Econom.Services.Searchers.Contracts
{
    using System.Linq;

    using ItemMasterData.Models;

    public interface IBarcodeSearcherService
    {
        IQueryable<Product> Search(string barcode);
    }
}
