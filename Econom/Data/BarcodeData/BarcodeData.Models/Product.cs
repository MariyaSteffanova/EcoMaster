namespace BarcodeData.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }
    }
}
