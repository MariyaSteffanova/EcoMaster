namespace Econom.Services.Data.Contracts
{
    using System.Collections.Generic;

    using Econom.Data.Models;
    using System.Linq;

    public interface IHomeStorageService
    {
        bool Exist(int id);

        IQueryable<HomeStorage> GetAll();

        HomeStorage Create(HomeStorage model, string userId);

        HomeStorage AddFlatmates(string ownerId, IEnumerable<string> userEmails);

        void Delete(int id);
    }
}
