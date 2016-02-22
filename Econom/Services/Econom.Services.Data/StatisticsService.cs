namespace Econom.Services.Data
{
    using Econom.Data;
    using Econom.Data.Contracts;
    using Econom.Data.Models;
    using Econom.Services.Data.Contracts;
    using System.Linq;
    using TransferModels;

    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<IEconomDbContext, HomeStorage> storages;

        public StatisticsService(IRepository<IEconomDbContext, HomeStorage> storages)
        {
            this.storages = storages;
        }

        public IQueryable<LocationStatistics> GetStoragesLocationStatistics()
        {
            var count = this.storages.All().Count();

            var result = this.storages.All()
                .GroupBy(x => x.Location.Country, (x, y) => new LocationStatistics
                {
                    Location = x,
                    Value = (y.Count() * 100) / count
                });

            return result.AsQueryable();

        }
    }
}
