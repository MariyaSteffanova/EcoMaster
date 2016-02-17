namespace ItemMasterData.Data
{
    using System.Data.Entity;

    using Models;
    using Migrations;

    public class ItemMasterDbContext : DbContext, IItemMasterDbContext
    {
        public ItemMasterDbContext()
            : base("ItemMasterDbConnection")
        {
        }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public static ItemMasterDbContext Create()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ItemMasterDbContext, Configuration>());
            return new ItemMasterDbContext();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
