namespace Econom.Web.Areas.Private.Controllers
{
    using System.Web.Mvc;

    using Econom.Data.Models;
    using Econom.Services.Data.Contracts;
   
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
            //// this.SetUser();
        }

        public User UserProfile { get; set; }

        public void SetUser()
        {
            var username = this.User.Identity.Name;
            this.UserProfile = this.users.GetByUserName(username);
        }
    }
}