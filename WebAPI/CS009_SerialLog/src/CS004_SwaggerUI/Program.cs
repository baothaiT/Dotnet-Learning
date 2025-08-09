using System.Diagnostics;
using CS004_SwaggerUI;
using CS004_SwaggerUI.Config;
using Microsoft.EntityFrameworkCore;
using Serilog;
using CS004_SwaggerUI.Middleware;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

// 1. Configure Serilog
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] TraceId={TraceId} {Message:lj}{NewLine}{Exception}")
    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

// Add OpenTelemetry Tracing
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("CS004_SwaggerUI"))
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddJaegerExporter(jaegerOptions =>
        {
            jaegerOptions.AgentHost = "localhost"; // Change if Jaeger is remote
            jaegerOptions.AgentPort = 6831;
        })
    );

builder.AddServiceDefaults();
builder.Services.ConfigureDB(builder);

builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureEventHandlers();

builder.Host.UseSerilog();

// 2. Add logging options to capture TraceId
builder.Logging.Configure(options =>
{
    options.ActivityTrackingOptions =
        ActivityTrackingOptions.TraceId |
        ActivityTrackingOptions.SpanId;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "docs";
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<TraceIdMiddleware>();
app.MapControllers();
app.Run();