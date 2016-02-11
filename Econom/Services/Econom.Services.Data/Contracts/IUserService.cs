namespace Econom.Services.Data.Contracts
{
    using System.Linq;

    using Econom.Data.Models;

    public interface IUserService
    {
        User GetById(string id);

        User GetByUserName(string username);

        IQueryable<User> GetAll();
    }
}
