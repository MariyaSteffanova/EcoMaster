namespace Econom.Web
{
    using System.Data.Entity;
    using Data;
    using Econom.Data.Migrations;
    using ItemMasterData.Data;
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EconomDbContext, Configuration>());
            EconomDbContext.Create().Database.Initialize(true);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ItemMasterDbContext,ItemMasterData.Data.Migrations.Configuration>());
            ItemMasterDbContext.Create().Database.Initialize(true);
        }
    }
}