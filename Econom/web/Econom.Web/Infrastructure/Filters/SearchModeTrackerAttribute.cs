namespace Econom.Web.Infrastructure.Filters
{
    using Econom.Common;
    using System.Web.Mvc;

    public class SearchModeTrackerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor.ActionName;
            filterContext.HttpContext.Session[GlobalConstants.ClientSearchMode] = actionDescriptor;

            base.OnActionExecuting(filterContext);
        }
    }
}
