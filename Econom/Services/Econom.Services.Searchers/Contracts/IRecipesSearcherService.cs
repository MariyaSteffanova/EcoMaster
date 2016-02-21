namespace Econom.Services.Searchers.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using TransferModels;

    public interface IRecipesSearcherService
    {
        IQueryable<RecipeResult> SearchRecipes(IEnumerable<int> storageProductsIds);
    }
}
