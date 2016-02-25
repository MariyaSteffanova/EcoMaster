namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProductService
    {
        Product GetById(int id);

        IQueryable<Product> GetAll();

        IQueryable<Product> GetByBarcode(string barcode);

        IQueryable<Product> GetByName(string name);

        void InsertMany(IEnumerable<Product> products);

        void Update(Product model);
    }
}
