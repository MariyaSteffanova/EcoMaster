namespace Econom.Web
{
    using System.Data.Entity;
    using Data;
    using Econom.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EconomDbContext, Configuration>());
            EconomDbContext.Create().Database.Initialize(true);
        }
    }
}