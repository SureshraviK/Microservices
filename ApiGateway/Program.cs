//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

// Configure Serilog
//Serilog.AspNetCore: Integrates Serilog with ASP.NET Core, replacing the default logging provider.
//Serilog.Sinks.Console: Enables log output to the console, which is very useful during development for real-time log monitoring.
//Serilog.Sinks.File: Enables logging to files on disk. This is useful for persistent storage, auditing, and post-event analysis.
//Serilog.Settings.Configuration: Allows Serilog to be configured via appsettings.json, so you can change log settings without modifying code.
//Serilog.Sinks.Async: Wraps logging sinks with asynchronous functionality to improve performance by offloading log processing to a background thread.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/apigateway.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
