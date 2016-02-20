namespace Econom.Services.Data.Contracts
{
    using System.Collections.Generic;

    using Econom.Data.Models;

    public interface IHomeStorageService
    {
        bool Exist(int id);

        HomeStorage Create(HomeStorage model, string userId);

        HomeStorage AddFlatmates(string ownerId, IEnumerable<string> userEmails);
    }
}
