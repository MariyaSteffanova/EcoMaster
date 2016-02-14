using Econom.Services.Logic.Contracts;
using Econom.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Public.Controllers
{
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
           return new FileContentResult(test, "image/jpeg");  
        }
    }
}