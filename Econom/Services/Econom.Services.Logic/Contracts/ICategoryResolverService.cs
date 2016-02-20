namespace Econom.Services.Logic.Contracts
{
    using Econom.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICategoryResolverService
    {
        Category Resolve(string[] searchTerm);
    }
}
