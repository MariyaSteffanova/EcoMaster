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
using Econom.Data.Static;

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
            var possibleIngredients = this.AnalyzeInput(storageProductsIds).ToList();

            return this.recipeProvider
                             .GetRecipes(possibleIngredients);
        }

        public IEnumerable<string> AnalyzeInput(IEnumerable<int> storageProductsIds)
        {
            return this.storageProducts
                              .ByIds(storageProductsIds)
                              .OrderBy(x => x.CreatedOn)
                              .Select(x => x.Product.Name)
                              .ToList()
                              .SelectMany(name => name
                                              .Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(word => word.ToLower())
                                              .Where(IsNotAcronim)
                                              .Where(DoesNotHaveAdjSuffix)
                                              .Where(IsNotNoise)
                                              .Where(IsNotAdjective));
        }

        private Func<string, bool> IsNotAcronim = x =>
        {
            if (x.Any(ch => !char.IsLetter(ch)))
            {
                return false;
            }

            return true;
        };

        private Func<string, bool> DoesNotHaveAdjSuffix = x =>
        {
            if (FoodDictionary.AdjectiveSuffixes.Any(suffix => x.EndsWith(suffix)))
            {
                return false;
            }

            return true;
        };

        private Func<string, bool> IsNotNoise = x =>
        {
            if (FoodDictionary.Noise.Contains(x))
            {
                return false;
            }

            return true;
        };

        private Func<string, bool> IsNotAdjective = x =>
        {
            if (FoodDictionary.Adjectives.Contains(x))
            {
                return false;
            }

            return true;
        };
    }
}