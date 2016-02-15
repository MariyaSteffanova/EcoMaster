using Microsoft.AspNet.Identity;

using Econom.Data.Models;
using Econom.Services.Data.Contracts;
using Econom.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Econom.Web.Areas.Private.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService users;

        public UserController(IUserService users)
        {
            this.users = users;
            //this.SetUser();
        }

        public User UserProfile { get; set; }

        public void SetUser()
        {
            var username = this.User.Identity.Name;
            this.UserProfile = this.users.GetByUserName(username);
        }
    }
}