namespace ItemMasterData.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using global::Data.Contracts;

    public interface IItemMasterDbContext : IDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Image> Images { get; set; }

        //DbSet<TEntity> Set<TEntity>() where TEntity : class;

        //DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        //int SaveChanges();
    }
}