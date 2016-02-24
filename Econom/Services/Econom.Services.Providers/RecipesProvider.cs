namespace Econom.Services.Providers
{
    using Econom.Services.Providers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Econom.Services.TransferModels;
    using System.Net.Http;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    public static class QueryCombinationGenerator
    {
        private static List<List<string>> queryVariations = new List<List<string>>();

        public static void ClearList()
        {
            queryVariations.Clear();
        }

        public static List<List<string>> GetQueryVariations(IList<string> ingredients)
        {
            var k = ingredients.Count();

            for (int i = 1; i <= k; i++)
            {
                GetVariationsWithoutRepetition(ingredients, Enumerable.Repeat<string>(string.Empty, i).ToList(), 0, i, 0);
            }

            return queryVariations.ToList();
        }

        public static void GetVariationsWithoutRepetition(IList<string> set, List<string> variations, int index, int k, int from)
        {
            if (index == k)
            {
                queryVariations.Add(new List<string>(variations));
                return;
            }

            for (int i = from; i < set.Count; i++)
            {

                variations[index] = set[i];

                GetVariationsWithoutRepetition(set, variations, index + 1, k, i + 1);
            }
        }
    }

    public class RecipesProvider : IRecipesProvider
    {
        private readonly string API_KEY = "90e7b386764d99c46d5d8f89fff4c3a3";
        private readonly string SEARCH_URL = "http://food2fork.com/api/search?key={0}&q={1}";
        private readonly string DETAILS_URL = "http://food2fork.com/api/get?key={0}&rId={1}";

        public IQueryable<RecipeResult> GetRecipes(IList<string> ingredients)
        {
            var result = new List<RecipeResult>();
            QueryCombinationGenerator.ClearList();

            var queryVariationsResult = QueryCombinationGenerator
                            .GetQueryVariations(ingredients)
                            .OrderByDescending(x => x.Count)
                            .ToList();

            this.GetRecipesList(result, queryVariationsResult.ToList());
            this.GetRecipesDetails(result);

            return result.AsQueryable();
        }

        private void GetRecipesDetails(List<RecipeResult> result)
        {
            foreach (var recipe in result)
            {
                var url = string.Format(DETAILS_URL, API_KEY, recipe.Food2ForkID);
                var responseString = this.Request(url);
                var ingredientsResponse = JsonConvert.DeserializeObject<RecipeDetailsQueryResponse>(responseString).Recipe;
                recipe.Ingredients = ingredientsResponse.Ingredients;
            }
        }

        private void GetRecipesList(List<RecipeResult> result, IEnumerable<List<string>> queryVariationsResult)
        {
            foreach (var query in queryVariationsResult)
            {
                if (result.Count >= 30)
                {
                    return;
                }

                var url = string.Format(SEARCH_URL, API_KEY, string.Join("&", query));
                var responseString = this.Request(url);

                var recipes = JsonConvert.DeserializeObject<RecipesQueryResponse>(responseString);
                result.AddRange(recipes.Recipes);
            }
        }

        private string Request(string url)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    return responseContent.ReadAsStringAsync().Result;
                }
            }

            return string.Empty;
        }
    }
}
