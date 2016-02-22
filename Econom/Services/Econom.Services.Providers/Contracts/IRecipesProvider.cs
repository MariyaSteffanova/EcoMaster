namespace Econom.Services.Providers.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using TransferModels;

    public interface IRecipesProvider
    {
        IQueryable<RecipeResult> GetRecipes(IList<string> ingredients);
    }
}
