﻿namespace Econom.Services.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using Contracts;
    using Econom.Data.Models;
    using Econom.Data.Contracts;
    using Econom.Data;
    using System.Collections.Generic;

    public class UserService : IUserService
    {
        private readonly IRepository<IEconomDbContext, User> users;

        public UserService(IRepository<IEconomDbContext, User> users)
        {
            this.users = users;
        }

        public bool IsOwner(string userId)
        {
            return this.users.All()
                            .Where(x => x.Id == userId)
                            .Select(x => x.HomeStorage == null ? false : true)
                            .FirstOrDefault();
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetFlatmates(string userId)
        {
            return this.users.All()
                .Where(x => x.Id == userId)
                .SelectMany(x => x.HomeStorage.Owners);
        }

        public IQueryable<User> GetByEmails(ICollection<string> emails)
        {
            return this.users.All()
                            .Where(x => emails.Contains(x.Email))
                            .Select(x => x);
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

        public void Update(User model)
        {
            this.users.Update(model);
            this.users.SaveChanges();
        }
    }
}
