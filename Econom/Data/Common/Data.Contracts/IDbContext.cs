﻿namespace Data.Contracts
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
