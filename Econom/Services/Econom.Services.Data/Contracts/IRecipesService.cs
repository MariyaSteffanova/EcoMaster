namespace Econom.Services.Data.Contracts
{
    public interface IRecipesService
    {
        int CreateBasic(string externalId, string title, string imageUrl, decimal rank); // TODO: Ingredients
    }
}
