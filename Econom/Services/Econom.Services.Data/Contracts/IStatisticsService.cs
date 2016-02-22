namespace Econom.Services.Data.Contracts
{
    using System.Linq;
    using TransferModels;

    public interface IStatisticsService
    {
        IQueryable<LocationStatistics> GetStoragesLocationStatistics();
    }
}
