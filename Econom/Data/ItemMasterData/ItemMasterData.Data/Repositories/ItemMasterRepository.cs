namespace ItemMasterData.Data.Repositories
{
    using Econom.Data.Contracts;

    public class ItemMasterRepository<T> : GenericRepository<T> where T : class
    {
        public ItemMasterRepository(IItemMasterDbContext context)
            : base(context)
        {
        }
    }
}
