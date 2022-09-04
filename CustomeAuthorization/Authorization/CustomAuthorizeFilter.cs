using CustomeAuthorization.Services;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CustomeAuthorization.Authorization
{
    public class CustomAuthorize : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var service = context.HttpContext.RequestServices.GetService<IMyService>();
            //Get header 
            var requestHeaders = context.HttpContext.Request.Headers["somekey"];
            if (requestHeaders.ToString() != "Hari")
            {
                throw new NotAuthorizedException();
            }

            // do some async actions ..etc. 
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
