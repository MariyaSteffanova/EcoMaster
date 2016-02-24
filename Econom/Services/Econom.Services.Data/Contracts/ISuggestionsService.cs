namespace Econom.Services.Data.Contracts
{
    public interface ISuggestionsService
    {
        int Create(string senderId, int recipeId, string notes);
    }
}
