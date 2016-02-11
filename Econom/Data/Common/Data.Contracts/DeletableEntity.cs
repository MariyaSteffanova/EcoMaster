using System;

namespace Econom.Data.Contracts
{
    public class DeletableEntity : IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
