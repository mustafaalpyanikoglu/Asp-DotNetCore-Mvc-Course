using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public class ReguestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;

        public ReguestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path.ToString() == "/alp")
            {
                await context.Response.WriteAsync("Hello world");
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
        }
    }
}
