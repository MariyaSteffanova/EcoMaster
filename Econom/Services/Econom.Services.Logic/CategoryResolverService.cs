namespace Econom.Services.Logic
{
    using System.Linq;
    using Econom.Services.Logic.Contracts;
    using System.Collections.Generic;
    using Econom.Data.Models;
    using Data.Contracts;
    public class CategoryResolverService : ICategoryResolverService
    {
        private readonly ICategoryService categories;

        public CategoryResolverService(ICategoryService categories)
        {
            this.categories = categories;
        }

        public Category Resolve(string[] searchTerm)
        {
            var matches = new List<Category>();

            foreach (var term in searchTerm)
            {
                var result = this.categories.GetByGS1(term);

                if (result != null)
                {
                    return result;
                }

                matches.AddRange(this.categories.GetByName(term));
            }

            switch (matches.Count)
            {
                case 0:
                    return null;
                case 1:
                    return matches.First();
                default:
                    // TODO: Send notification to Administrator with list of categories for approvement
                    return matches
                        .OrderBy(x => x.Name.Length)
                        .FirstOrDefault();
            }

        }
    }
}
