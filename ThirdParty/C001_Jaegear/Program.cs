using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure OpenTelemetry Tracing with Jaeger Exporter
builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("JaegerExampleService"))
            .AddAspNetCoreInstrumentation()    // Enables tracing for ASP.NET Core requests
            .AddHttpClientInstrumentation()     // Enables tracing for HttpClient calls
            .AddJaegerExporter(options =>
            {
                options.AgentHost = "localhost"; // Jaeger host
                options.AgentPort = 6831;        // Jaeger port (default is 6831)
            });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
