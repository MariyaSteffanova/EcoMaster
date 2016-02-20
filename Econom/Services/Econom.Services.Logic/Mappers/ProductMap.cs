namespace Econom.Services.Logic.Mappers
{
    using Econom.Data.Models;
    using Econom.Data.TransferModels;
    using System;

    public static class ProductMap
    {
        public static Func<ProductBase, Product> FromBaseProduct = x =>
        {
            return new Product
            {
                Name = x.Description,
                Barcode = x.Barcode,
             //  Category = x.CategoryGS1 ?? 
                ImageUrl = x.ImageUrl
            };
        };

    }
}
