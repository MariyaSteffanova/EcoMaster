namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Linq;

    public interface IProductService
    {
        IQueryable<Product> SearchByBarcode(string barcode);

        IQueryable<Product> SearchByName(string name);
    }
}
