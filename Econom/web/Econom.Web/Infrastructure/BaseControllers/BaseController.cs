namespace Econom.Web.Infrastructure.BaseControllers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    // TODO: Rename the namespace if not moving from here
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);



            if (Request["aspxerrorpath"] != null)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "NotFound"

                };
            }

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (this.Request.IsAjaxRequest())
            {
                var exception = filterContext.Exception as HttpException;

                if (exception != null)
                {
                    this.Response.StatusCode = exception.GetHttpCode();
                    this.Response.StatusDescription = exception.Message;
                }
            }
            else
            {
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString();
                var actionName = this.ControllerContext.RouteData.Values["Action"].ToString();
                this.View("Error", new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            }

            filterContext.ExceptionHandled = true;
        }
    }
}
