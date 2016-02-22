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

        public static void GetVariationsWithoutRepetition(IList<string> set, List<string>variations, int index, int k, int from)
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
        private readonly string API_KEY = "";
        private readonly string SEARCH_URL = "http://food2fork.com/api/search?key={0}&q={1}";
       

        public RecipesProvider()
        {
           // queryVariations = new List<string[]>();
        }

        public IQueryable<RecipeResult> GetRecipes(IList<string> ingredients)
        {
            var result = new List<RecipeResult>();

            // TODO: Get listS with recipes from combination of ingredients
            // TODO: Order by matches, keeping the dateTime ordering
            var queryVariationsResult = QueryCombinationGenerator
                            .GetQueryVariations(ingredients)
                            .OrderByDescending(x=>x.Count);


            foreach (var query in queryVariationsResult)
            {
                var url = string.Format(SEARCH_URL, API_KEY, string.Join("&", query));

                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;

                        string responseString = responseContent.ReadAsStringAsync().Result;
                        var recipes = JsonConvert.DeserializeObject<RecipesQueryResponse>(responseString);
                        result.AddRange(recipes.Recipes);
                    }
                }
            }

            return result.AsQueryable();
        }
    }
}
