namespace Econom.Web.Areas.Public.ViewModels.Products
{
    using System.Web.Mvc;

    public class ProductBaseViewModel
    {
        public string Barcode { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string ImageUrl { get; set; }
    }
}
