namespace BarcodeData.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BarcodeData.Data.BarcodeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BarcodeData.Data.BarcodeDbContext";
        }

        protected override void Seed(BarcodeData.Data.BarcodeDbContext context)
        {
        }
    }
}
