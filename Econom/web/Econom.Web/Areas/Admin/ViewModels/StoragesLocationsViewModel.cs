using Econom.Services.TransferModels;
using Econom.Web.Infrastructure.Mapping;

namespace Econom.Web.Areas.Admin.ViewModels
{
    public class StoragesLocationsViewModel : IMapFrom<LocationStatistics>
    {
        public string Location { get; set; }

        public double Value { get; set; }
    }
}
