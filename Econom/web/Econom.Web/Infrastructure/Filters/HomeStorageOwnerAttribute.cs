namespace Econom.Web.Infrastructure.Filters
{
    using Econom.Services.Data.Contracts;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using Ninject;
    using Common;
    using System.Web.Routing;
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class HomeStorageOwnerAttribute : ActionFilterAttribute
    {
        [Inject]
        public IUserService Users { private get; set; }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var user = this.Users.GetById(userId);

            if (user.HomeStorageID == null)
            {
                //filterContext.Result = new RedirectToRouteResult(
                //new RouteValueDictionary
                //{
                //    { "controller", "HomeStorage" },
                //    { "action", "Create" }
                //});

                //filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);

                filterContext.Result = new RedirectResult("/Private/HomeStorage/Create");

            }
            base.OnActionExecuting(filterContext);
        }
    }
}
