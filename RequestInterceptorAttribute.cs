using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequestInterceptorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var method = filterContext.HttpContext.Request.Method;
            var form = filterContext.HttpContext.Request.Form;
            var query = filterContext.HttpContext.Request.Query;
            var headers = filterContext.HttpContext.Request.Headers;
            var controller = filterContext.ActionDescriptor.DisplayName;

        }
    }
}
