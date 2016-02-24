using Econom.Data.Models;

namespace Econom.Services.Data.Contracts
{
    public interface ISuggestionsService
    {
        Suggestion Create(string senderId, int recipeId, string notes);
    }
}
