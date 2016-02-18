namespace Econom.Services.Data.Contracts
{
    using Econom.Data.Models;

    public interface IHomeStorageService
    {
        HomeStorage Create(HomeStorage model, string userId);
    }
}
