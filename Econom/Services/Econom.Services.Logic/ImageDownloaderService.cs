namespace Econom.Services.Logic
{
    using System.Net.Http;
    using System.Threading.Tasks;

    using Contracts;
    using System.Net;
    using System.IO;
    public class ImageDownloaderService : IImageDownloaderService
    {
        public byte[] DownloadFromUri(string uri)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    var memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }

            // return Task.Run(async () =>
            //  {
            //using (var client = new HttpClient())
            //    {
            //       // var stream = client.GetStreamAsync("https://scontent-frt3-1.xx.fbcdn.net/hphotos-xat1/v/t1.0-9/12289642_1183804578301916_8282521644435051935_n.jpg?oh=3f6d4458591beda5ca286d4269ecb865&oe=5724CC7F");
            //        var rawresponse =   client.GetByteArrayAsync(uri).Result;

            //        return rawresponse;// TODO:
            //    }

           // });
        }
    }
}
