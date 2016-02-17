namespace BarcodeData.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
