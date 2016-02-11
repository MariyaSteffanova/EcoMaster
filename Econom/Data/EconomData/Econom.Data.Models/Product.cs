namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Index]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Index]
        [Required]
        [MaxLength(50)]
        public string Barcode { get; set; }

        public byte[] Image { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public int EcoInfoID { get; set; }

        [ForeignKey("EcoInfoID")]
        public virtual EcoInfo EcoInfo { get; set; }
    }
}
