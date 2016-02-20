namespace Econom.Services.Logic.Contracts
{
    using Econom.Data.Models;
    using System.Linq;

    public interface IProductProcessorService
    {
        IQueryable<Product> ProcessByBarcode(string barcode);
    }
}
