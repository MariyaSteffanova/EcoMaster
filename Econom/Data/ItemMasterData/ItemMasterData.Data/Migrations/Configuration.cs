namespace ItemMasterData.Data.Migrations
{
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ItemMasterData.Data.ItemMasterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ItemMasterDbContext context)
        {
            base.Seed(context);
        }
    }
}