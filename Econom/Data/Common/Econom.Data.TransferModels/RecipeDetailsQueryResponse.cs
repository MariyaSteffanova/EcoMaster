namespace Econom.Services.TransferModels
{
    using Newtonsoft.Json;

    public class RecipeDetailsQueryResponse
    {
        [JsonProperty("recipe")]
        public RecipeResult Recipe { get; set; }
    }
}
