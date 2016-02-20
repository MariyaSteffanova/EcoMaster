namespace Econom.Services.Logic.Contracts
{
    using Econom.Data.Models;
    using System.Linq;

    public interface IProductProcesorService
    {
        IQueryable<Product> ProcessByBarcode(string barcode);
    }
}
