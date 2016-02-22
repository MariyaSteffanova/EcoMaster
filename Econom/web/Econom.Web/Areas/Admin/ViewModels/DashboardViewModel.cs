namespace Econom.Web.Areas.Admin.ViewModels
{
    using System.Collections.Generic;

    public class DashboardViewModel
    {
        public IEnumerable<StoragesLocationsViewModel> LocationsMap { get; set; }
    }
}
