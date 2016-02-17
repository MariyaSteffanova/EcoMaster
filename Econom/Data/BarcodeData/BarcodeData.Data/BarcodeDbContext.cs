namespace BarcodeData.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Models;
    using Migrations;

    public class BarcodeDbContext : DbContext,  IBarcodeDbContext
    {
        public BarcodeDbContext()
            : base("BarcodeDbConnection")
        {
        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<UPC> Barcodes { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public static BarcodeDbContext Create()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BarcodeDbContext, Configuration>());
            return new BarcodeDbContext();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
