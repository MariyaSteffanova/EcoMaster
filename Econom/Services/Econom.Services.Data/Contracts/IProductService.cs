namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProductService
    {
        Product GetById(int id);

        void InsertMany(IEnumerable<Product> products);

        IQueryable<Product> SearchByName(string name);
        
    }
}
