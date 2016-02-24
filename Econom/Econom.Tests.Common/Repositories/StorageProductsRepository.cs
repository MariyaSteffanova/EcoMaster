namespace Econom.Tests.Common.Repositories
{
    using Econom.Data.Models;
    using System;
    using System.Collections.Generic;

    public class StorageProductsRepository
    {
        private static List<string> foods = new List<string>
        { "apple", "orange", "banana", "boiled beans", "smashed potatoes", "baked", "healthy", "strong" ,
        "deliciuous", "all baked", "organic apple", "nature food"};

        public static List<StorageProduct> Get()
        {
            var products = new List<StorageProduct>();

            for (int i = 0; i < foods.Count; i++)
            {
                products.Add(new StorageProduct
                {
                    ID = i,
                    CreatedOn = DateTime.Now.AddDays(i * (-1)),
                    Product = new Product
                    {
                        Name = foods[i]
                    }
                });
            }
            return products;
        }
    }
}
