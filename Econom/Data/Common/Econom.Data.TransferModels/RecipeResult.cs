namespace Econom.Services.TransferModels
{
    using System.Collections.Generic;

    public class RecipeResult
    {
        public int Food2ForkID { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public decimal SocialRank { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}
