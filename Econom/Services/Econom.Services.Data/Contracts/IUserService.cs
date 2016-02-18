namespace Econom.Services.Data.Contracts
{
    using System.Linq;

    using Econom.Data.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        User GetById(string id);

        User GetByUserName(string username);

        IQueryable<User> GetAll();

        IQueryable<User> GetByEmails(ICollection<string> emails);
    }
}
