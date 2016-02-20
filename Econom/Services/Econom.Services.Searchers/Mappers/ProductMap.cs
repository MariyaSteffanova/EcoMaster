namespace Econom.Services.Searchers.Mappers
{
    using Data.Models;
    using Data.TransferModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public static class ProductMap
    {
        public static Func<ProductBase, Product> FromBaseProduct = x =>
        {
            return new Product
            {
                Name = x.Description,
                Barcode = x.Barcode,
                //Category 
                ImageUrl = x.ImageUrl
            };
        };

    }
}
