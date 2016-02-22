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

        public static List<List<string>> GetQueryVariations(IList<string> ingredients)
        {
            var k = ingredients.Count();

            for (int i = 1; i <= k; i++)
            {
                GetVariationsWithoutRepetition(ingredients, Enumerable.Repeat<string>(string.Empty, i).ToList(), 0, i, 0);
            }

            return queryVariations;
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
        private readonly string API_KEY = "d6f6d7468f88b4abb9f2c6ddb44020eb";
        private readonly string SEARCH_URL = "http://food2fork.com/api/search?key={0}&q={1}";
        private readonly string DETAILS_URL = "http://food2fork.com/api/get?key={0}&rId={1}";

        public IQueryable<RecipeResult> GetRecipes(IList<string> ingredients)
        {
            var result = new List<RecipeResult>();

            var queryVariationsResult = QueryCombinationGenerator
                            .GetQueryVariations(ingredients)
                            .OrderByDescending(x => x.Count);

            this.GetRecipesList(result, queryVariationsResult);
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
                recipe.Ingredients =ingredientsResponse.Ingredients;
            }
        }

        private void GetRecipesList(List<RecipeResult> result, IOrderedEnumerable<List<string>> queryVariationsResult)
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
