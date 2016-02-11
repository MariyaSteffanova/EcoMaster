namespace Econom.Services.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Contracts;
    using Econom.Data.Models;
    using Econom.Data.Contracts;
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string id)
        {
            return this.users.All()
                             .Where(x => x.Id == id)
                             .FirstOrDefault();
        }

        public User GetByUserName(string username)
        {
            return this.users.All()
                             .Where(x => x.UserName == username)
                             .FirstOrDefault();
        }
    }
}
