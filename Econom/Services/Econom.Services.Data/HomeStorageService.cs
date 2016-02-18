namespace Econom.Services.Data
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Econom.Data.Models;
    using Econom.Data;
    using Econom.Data.Contracts;
    public class HomeStorageService : IHomeStorageService
    {
        private readonly IRepository<IEconomDbContext, HomeStorage> storages;
        private readonly IRepository<IEconomDbContext, User> users;

        public HomeStorageService(IRepository<IEconomDbContext, HomeStorage> storages,  IRepository<IEconomDbContext, User> users)
        {
            this.storages = storages;
            this.users = users;
        }

        public HomeStorage Create(HomeStorage model, string userId)
        {
            model.Owners.Add(this.users.All().FirstOrDefault(x => x.Id == userId));
            this.storages.Add(model);
            this.storages.SaveChanges();

            return model;
        }
    }
}
