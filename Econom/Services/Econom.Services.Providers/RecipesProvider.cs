namespace Econom.Services.Providers
{
    using Econom.Services.Providers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Econom.Services.TransferModels;

    public class RecipesProvider : IRecipesProvider
    {
        public IQueryable<RecipeResult> GetRecipes(IEnumerable<string> ingredients)
        {
            throw new NotImplementedException();
        }
    }
}
