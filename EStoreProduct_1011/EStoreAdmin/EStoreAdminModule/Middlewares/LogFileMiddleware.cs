namespace EStoreAdminModule.Middlewares
{
    public class LogFileMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Logging to File Started...\n");

            await next(context);

            await context.Response.WriteAsync("Logging to File Ended...\n");
        }
    }
}
