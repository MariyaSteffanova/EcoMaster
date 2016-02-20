namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EcoInfo
    {
        [Key]
        public int ID { get; set; }

        public decimal Percentage { get; set; }

        public string Notes { get; set; }

    }
}
