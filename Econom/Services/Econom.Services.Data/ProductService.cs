namespace Econom.Services.Data
{
    using Contracts;
    using Econom.Data;
    using Econom.Data.Contracts;
    using Econom.Data.Models;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using Common.Extensions;

    public class ProductService : IProductService
    {
        private readonly IRepository<IEconomDbContext, Product> products;

        public ProductService(IRepository<IEconomDbContext, Product> products)
        {
            this.products = products;
        }

        public Product GetById(int id)
        {
            return this.products.All().FirstOrDefault(x => x.ID == id);
        }


        public IQueryable<Product> GetByBarcode(string barcode)
        {
            return this.products.All()
                .Where(x => x.Barcode == barcode);
        }

        public IQueryable<Product> GetByName(string name)
        {
            return this.products.All()
                .Where(x => x.Name == name);
        }

        public void InsertMany(IEnumerable<Product> products)
        {
            products.ForEach(x =>
            {
                this.products.Add(x);
            });

            this.products.SaveChanges();
            var a = products;

        }
    }
}
