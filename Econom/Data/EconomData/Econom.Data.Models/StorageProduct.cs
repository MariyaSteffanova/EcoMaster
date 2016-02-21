namespace Econom.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public class StorageProduct : AuditInfo, IDeletableEntity
    {
        [Key]
        public int ID { get; set; }

        public double Quantity { get; set; }

        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        public int HomeStorageID { get; set; }

        [ForeignKey("HomeStorageID")]
        public virtual HomeStorage HomeStorage { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
