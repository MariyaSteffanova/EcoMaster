using Econom.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econom.Data.Models;
using Econom.Data.Contracts;
using Econom.Data;

namespace Econom.Services.Data
{
    public class StorageProductsService : IStorageProductsService
    {
        private readonly IRepository<IEconomDbContext, HomeStorage> storages;
        private readonly IRepository<IEconomDbContext, StorageProduct> products;
        private readonly IUserService users;

        public StorageProductsService(IRepository<IEconomDbContext, HomeStorage> storages, IRepository<IEconomDbContext, StorageProduct> products, IUserService users)
        {
            this.storages = storages;
            this.products = products;
            this.users = users;
        }

        public IQueryable<StorageProduct> All(string userId)
        {
            var homeStorageId = (int)this.users.GetAll().FirstOrDefault(x => x.Id == userId).HomeStorageID;

            return this.storages
                .All()
                .Where(x => x.ID == homeStorageId)
                .SelectMany(x => x.Products.Where(p => !p.IsDeleted));
        }

        public void Add(int productId, string userId)
        {
            var homeStorageId = (int)this.users.GetAll().FirstOrDefault(x => x.Id == userId).HomeStorageID;

            this.products.Add(new StorageProduct()
            {
                ProductID = productId,
                HomeStorageID = homeStorageId
            });

            this.products.SaveChanges();
        }

        public void Update(int id, double quantity)
        {
            var product = this.products.All().FirstOrDefault(x => x.ID == id);

            product.Quantity = quantity;
            this.products.SaveChanges();

        }

        public void Delete(int id)
        {
            this.products.Delete(id);
            this.products.SaveChanges();
        }
    }
}
