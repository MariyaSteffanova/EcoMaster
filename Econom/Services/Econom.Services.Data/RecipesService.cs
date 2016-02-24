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
    public class RecipesService : IRecipesService
    {
        private readonly IRepository<IEconomDbContext, Recipe> recipes;

        public RecipesService(IRepository<IEconomDbContext, Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public int CreateBasic(string externalId, string title, string imageUrl, decimal rank)
        {
            var recipe = new Recipe
            {
                Title = title,
                ExternalID = externalId,
                ImageUrl = imageUrl,
                SocialRank = rank
            };

            this.recipes.Add(recipes);
            this.recipes.SaveChanges();

            return recipe.ID;

        }
    }
}
