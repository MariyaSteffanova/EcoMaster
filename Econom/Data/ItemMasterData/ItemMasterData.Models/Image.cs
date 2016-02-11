namespace ItemMasterData.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string MimeType { get; set; }

        public string Url { get; set; }
    
        public int? ProductId { get; set; }

       // public virtual Product Product { get; set; }
    }
}
