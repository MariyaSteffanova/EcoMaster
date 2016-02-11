namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
