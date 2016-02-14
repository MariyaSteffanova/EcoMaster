namespace Econom.Services.Logic.Contracts
{
    using System.Threading.Tasks;

    public interface IImageDownloaderService
    {
       Task<byte[]> DownloadFromUri(string uri);
    }
}
