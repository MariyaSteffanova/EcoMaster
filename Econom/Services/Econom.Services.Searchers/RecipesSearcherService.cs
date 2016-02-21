using Econom.Data.Contracts;
using Econom.Services.Data.Contracts;
using Econom.Services.Searchers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Econom.Data.Models;
using Econom.Services.Providers.Contracts;
using Econom.Services.TransferModels;

namespace Econom.Services.Searchers
{
    public class RecipesSearcherService : IRecipesSearcherService
    {
        private readonly IStorageProductsService storageProducts;
        private readonly IRecipesProvider recipeProvider;

        public RecipesSearcherService(IStorageProductsService storageProducts, IRecipesProvider recipeProvider)
        {
            this.storageProducts = storageProducts;
            this.recipeProvider = recipeProvider;
        }

        public IQueryable<RecipeResult> SearchRecipes(IEnumerable<int> storageProductsIds)
        {
            var possibleIngredients = this.storageProducts
                            .ByIds(storageProductsIds)
                            .OrderBy(x => x.CreatedOn)
                            .Select(x => x.Product.Name)
                            .SelectMany(name => name
                                            .Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(word => word.ToLower()));

           return this.recipeProvider
                            .GetRecipes(possibleIngredients);                            
        }
    }
}