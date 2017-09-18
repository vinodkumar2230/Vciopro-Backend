using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeUser.Filters
{
    //public class HasTenantIdAttribute:ActionFilterAttribute ,IActionFilter
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        if(filterContext.HttpContext.Request.IsAjaxRequest()){
    //            if (filterContext.HttpContext.Session["TenantId"] == null)
    //            {
    //               // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "LogOff", controller = "Account" }));
    //                // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "#" }));
                 
    //            }
    //        }
            

    //    }

    //}
        public class SessionTimeoutFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            // If the browser session or authentication session has expired...
            if (session.IsNewSession || session["TenantId"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // For AJAX requests, return result as a simple string, 
                    // and inform calling JavaScript code that a user should be redirected.
                    JsonResult result = new JsonResult();
                    result.ContentType = "text/html";
                    result.Data = "SessionTimeout";
                    filterContext.Result = result;

                }
                else
                {
                //    // For round-trip requests,
                //    filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary {
                //{ "Controller", "Account" },
                //{ "Action", "Login" }
                //    });
                }
            }
            base.OnActionExecuting(filterContext);
        }
        //other methods...
    }
}