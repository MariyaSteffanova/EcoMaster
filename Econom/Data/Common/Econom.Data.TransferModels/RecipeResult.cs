namespace Econom.Services.TransferModels
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class RecipeResult
    {
        [JsonProperty("recipe_id")]
        public string Food2ForkID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("social_rank")]
        public string SocialRank { get; set; }

        [JsonProperty("ingredients")]
        public IEnumerable<string> Ingredients { get; set; }
    }
}
