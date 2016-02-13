namespace Econom.Data.TransferModels
{
    public class ProductBase
    {
        public string Barcode { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public byte[] Image { get; set; }
    }
}
