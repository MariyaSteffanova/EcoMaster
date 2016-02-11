namespace ItemMasterData.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string GS1 { get; set; }
    }
}
