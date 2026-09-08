//Create Builder is a method will development / create in stance of a Application Builder,
//which is used to configure and build the application.
//It provides a fluent interface for configuring services, middleware, and
//other application settings. The builder is typically used in the startup process of an application
//to set up the necessary components before running the application.
using EStoreAdminModule.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<LogMiddleware>();

builder.Services.AddTransient<LogFileMiddleware>();

var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome To Dotnet Core Microservices Learning...\n");
    await next(context);
});

app.UseMiddleware<LogMiddleware>();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome To ITask Technologies...\n");
    await next(context);
});

app.UseMiddleware<LogFileMiddleware>();

//extension method to add the LogToDBMiddleware to the
//HTTP request pipeline
app.UseLogToDBMiddleware();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello, World!... \n");
});

app.Run();
