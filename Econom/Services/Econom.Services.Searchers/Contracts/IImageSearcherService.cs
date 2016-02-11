namespace Econom.Services.Searchers.Contracts
{
    using System.Collections.Generic;

    public interface IImageSearcherService
    {
        ICollection<string> FindImages(string searchTerm);
    }
}
