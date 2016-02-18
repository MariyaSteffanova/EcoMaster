namespace Econom.Web.Areas.Public.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Econom.Services.Logic.Contracts;

    public class ImagesController : BaseController
    {
        private readonly IImageDownloaderService imageDownloader;
        private readonly IImageProcessorService imageProcessor;

        public ImagesController(IImageDownloaderService imageDownloader, IImageProcessorService imageProcessor)
        {
            this.imageDownloader = imageDownloader;
            this.imageProcessor = imageProcessor;
        }

        // GET: Public/Images
        public async Task<ActionResult> GetImage(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return new FilePathResult("~/Content/Images/background.jpg", "image/jpeg");
            }

            var image = await this.imageDownloader.DownloadFromUri(url);
            var test = await this.imageProcessor.Resize(image, 200);

            return new FileContentResult(image, "image/jpeg");
        }
    }
}