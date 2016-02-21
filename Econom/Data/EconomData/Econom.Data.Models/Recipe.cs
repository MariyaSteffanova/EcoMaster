namespace Econom.Data.Models
{
    using Econom.Data.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Recipe : AuditInfo
    {
        private ICollection<string> ingredients;
        private ICollection<StorageProduct> products;

        public Recipe()
        {
            this.ingredients = new HashSet<string>();
            this.products = new HashSet<StorageProduct>();
        }

        [Key]
        public int ID { get; set; }

        public int ExternalID { get; set; }

        public string Title { get; set; }

        public decimal SocialRank { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<string> Ingredients { get; set; }

        public virtual ICollection<StorageProduct> StorageProduct
        {
            get { return this.products; }
            set { this.products = value; }
        }

    }
}
