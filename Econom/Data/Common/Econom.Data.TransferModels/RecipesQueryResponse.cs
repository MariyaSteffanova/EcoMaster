namespace Econom.Services.TransferModels
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class RecipesQueryResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("recipes")]
        public ICollection<RecipeResult> Recipes { get; set; }
    }
}
