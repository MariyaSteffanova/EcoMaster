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

        public void Add(int productId, string userId)
        {
            var homeStorageId = (int)this.users.GetAll().FirstOrDefault(x => x.Id == userId).HomeStorageID;

            this.products.Add(new StorageProduct()
            {
                ProductID = productId,
                HomeStorageID = homeStorageId
            });

            this.products.SaveChanges();
            //this.storages.All()
            //    .FirstOrDefault(x => x.Owners
            //            .Any(o => o.Id == userId))
            //    .Products
            //    .Add(new StorageProduct()
            //    {
            //        ProductID = productId,
            //        Quantity = 1
            //    });

            //this.storages.SaveChanges();
        }
    }
}
