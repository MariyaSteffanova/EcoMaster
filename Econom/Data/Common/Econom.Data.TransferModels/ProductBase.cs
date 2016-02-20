namespace Econom.Data.TransferModels
{
    public class ProductBase
    {
        public int Id { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string CategoryGS1 { get; set; }

        public string ImageUrl { get; set; }

        public byte[] Image { get; set; }
    }
}
