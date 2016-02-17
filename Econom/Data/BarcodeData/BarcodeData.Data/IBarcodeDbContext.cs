namespace BarcodeData.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IBarcodeDbContext
    {
        IDbSet<Product> Products { get; set; }

        IDbSet<UPC> Barcodes { get; set; }

        IDbSet<Image> Images { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
