namespace Econom.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;
    using global::Data.Contracts;

    public interface IEconomDbContext : IDisposable, IDbContext
    {
        IDbSet<User> Users { get; set; }
    }
}