namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface IStorageProductsService
    {
        IQueryable<StorageProduct> All(string userId);

        IQueryable<StorageProduct> ByIds(IEnumerable<int> ids);

        void Add(int productId, string userId);

        void Update(int id, double quantity);

        void Delete(int id);
    }
}
