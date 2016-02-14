namespace Econom.Services.Logic.Contracts
{
    using System.Threading.Tasks;

    public interface IImageDownloaderService
    {
        byte[] DownloadFromUri(string uri);
    }
}
