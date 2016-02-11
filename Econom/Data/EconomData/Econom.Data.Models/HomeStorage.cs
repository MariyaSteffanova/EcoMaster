namespace Econom.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Contracts;

    public class HomeStorage : AuditInfo
    {
        private ICollection<StorageProduct> products;
        private ICollection<User> owners;

        public HomeStorage()
        {
            this.products = new HashSet<StorageProduct>();
            this.owners = new HashSet<User>();
        }

        [Key]
        public int ID { get; set; }

        public int LocationID { get; set; }

        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        public ICollection<StorageProduct> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public ICollection<User> Owners
        {
            get { return this.owners; }
            set { this.owners = value; }
        }
    }
}
