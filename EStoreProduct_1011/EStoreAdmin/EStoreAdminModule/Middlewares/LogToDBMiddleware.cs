using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EStoreAdminModule.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LogToDBMiddleware
    {
        private readonly RequestDelegate _next;

        public LogToDBMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Logging to Database Started...\n");
            await  _next(httpContext);
            await httpContext.Response.WriteAsync("Logging to Database Ended...\n");    
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogToDBMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogToDBMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogToDBMiddleware>();
        }
    }
}
