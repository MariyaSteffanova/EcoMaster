namespace Econom.Web.Areas.Private.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Econom.Services.Data.Contracts;
    using Econom.Web.Areas.Private.ViewModels;

    public class FlatmatesController : Controller
    {
        private readonly IUserService userService;

        public FlatmatesController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Get(ICollection<string> emails)
        {
            var users = this.userService.GetByEmails(emails)
                .Select(x => new FlatmateViewModel()
                {
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName,
                    ImageUrl = x.ImageUrl
                })
                .ToList();

            return this.PartialView("_FlatmatesGridView", users);
        }
    }
}