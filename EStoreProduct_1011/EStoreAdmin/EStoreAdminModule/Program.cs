//Create Builder is a method will development / create in stance of a Application Builder,
//which is used to configure and build the application.
//It provides a fluent interface for configuring services, middleware, and
//other application settings. The builder is typically used in the startup process of an application
//to set up the necessary components before running the application.
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();
