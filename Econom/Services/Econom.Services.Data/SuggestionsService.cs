using Econom.Common;
using Econom.Data;
using Econom.Data.Contracts;
using Econom.Data.Models;
using Econom.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econom.Services.Data
{
    public class SuggestionsService : ISuggestionsService
    {
        private readonly IRepository<IEconomDbContext, Suggestion> suggestions;

        public SuggestionsService(IRepository<IEconomDbContext, Suggestion> suggestions)
        {
            this.suggestions = suggestions;
        }

        public Suggestion Create(string senderId, int recipeId, string notes)
        {
            var suggestion = new Suggestion
            {
                Notes = string.IsNullOrEmpty(notes) ? GlobalConstants.DefaultSuggestionNotes : notes,
                RecipeID = recipeId,
                SenderID = senderId
            };

            this.suggestions.Add(suggestion);
            this.suggestions.SaveChanges();
            return suggestion;
        }
    }
}
