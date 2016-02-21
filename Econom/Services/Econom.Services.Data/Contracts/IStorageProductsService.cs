namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Linq;

    public interface IStorageProductsService
    {
        IQueryable<StorageProduct> All(string userId);

        void Add(int productId, string userId);

        void Update(int id, double quantity);

        void Delete(int id);
    }
}
