namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public class StorageProduct : AuditInfo
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
    }
}
