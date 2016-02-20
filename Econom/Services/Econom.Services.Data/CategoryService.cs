namespace Econom.Services.Data
{
    using Econom.Services.Data.Contracts;
    using System.Linq;
    using Econom.Data.Models;
    using Econom.Data;
    using Econom.Data.Contracts;

    public class CategoryService : ICategoryService
    {

        private readonly IRepository<IEconomDbContext, Category> categories;

        public CategoryService(IRepository<IEconomDbContext, Category> categories)
        {
            this.categories = categories;
        }

        public Category GetByGS1(string gs1)
        {
            return this.categories
                .All()
                .FirstOrDefault(x => x.GS1.ToLower().Trim() == gs1.ToLower().Trim());
        }

        public IQueryable<Category> GetByName(string name)
        {
            return this.categories
                 .All()
                 .Where(x => x.Name.Contains(name));
        }
    }
}
