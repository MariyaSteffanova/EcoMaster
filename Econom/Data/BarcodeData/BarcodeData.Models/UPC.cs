namespace BarcodeData.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UPC
    {
        [Key]
        public int Id { get; set; }

        [Index]
        [MaxLength(25)]
        public string Barcode { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
