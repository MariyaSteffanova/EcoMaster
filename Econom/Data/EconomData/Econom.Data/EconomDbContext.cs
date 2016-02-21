namespace Econom.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Econom.Data.Contracts;
    using Econom.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EconomDbContext : IdentityDbContext<User>, IEconomDbContext
    {
        public EconomDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<HomeStorage> HomeStorages { get; set; }

        public IDbSet<StorageProduct> StorageProducts { get; set; }

        public IDbSet<EcoInfo> EcoInfos { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Notification> Notification { get; set; }

        public IDbSet<Suggestion> Suggestions { get; set; }

        public static EconomDbContext Create()
        {
            return new EconomDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
