namespace Econom.Web.Infrastructure.Filters
{
    using System;
    using System.Web.Mvc;

    using Econom.Services.Data.Contracts;

    using Microsoft.AspNet.Identity;
    using Ninject;
    using Common;
    using Services.Data;
    using Data.Contracts;
    using Data;
    using Data.Models;

    [AttributeUsage(AttributeTargets.Method)]
    public class HomeStorageOwnerAttribute : ActionFilterAttribute
    {
        //[Inject]
        //public IUserService Users { get; set; }

        private readonly IUserService users;

        public HomeStorageOwnerAttribute(IUserService users)
        {
            this.users = users;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var user = this.users.GetById(userId);

            if (user.HomeStorageID == null)
            {
                if (filterContext.ActionDescriptor.ActionName == "AddProduct")
                {
                    filterContext.HttpContext.Session[GlobalConstants.PendingHomestorageCreationProductId] = filterContext.HttpContext.Request.Params["id"];
                }

                filterContext.Result = new RedirectResult("/Private/HomeStorage/Create");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
