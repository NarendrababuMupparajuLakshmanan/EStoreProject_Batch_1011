namespace EStoreAdminModule.Middlewares
{
    public class LogMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Logging Started...\n");

            await next(context);

            await context.Response.WriteAsync("Logging Ended...\n");
        }
    }
}
