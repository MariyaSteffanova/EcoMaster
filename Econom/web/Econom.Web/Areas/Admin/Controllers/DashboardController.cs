namespace Econom.Web.Areas.Admin.Controllers
{
    using Common;
    using Infrastructure.BaseControllers;
    using Infrastructure.Mapping;
    using Services.Data.Contracts;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels;

    [Authorize(Roles = GlobalConstants.AdminUserRole)]
    public class DashboardController : BaseMapController
    {
        private readonly IStatisticsService statistics;

        public DashboardController(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }

        public ActionResult Index()
        {
            var locationStatistics = this.statistics
                        .GetStoragesLocationStatistics()
                        .To<StoragesLocationsViewModel>()
                        .ToList();

            var viewModel = new DashboardViewModel
            {
                LocationsMap = locationStatistics
            };

            return View(viewModel);
        }

    }
}