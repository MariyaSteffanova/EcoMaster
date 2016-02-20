namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;
    using System.Linq;

    public interface ICategoryService
    {
        IQueryable<Category> GetByName(string name);

        Category GetByGS1(string gs1);
    }
}
