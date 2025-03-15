using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Data.SqlTypes;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Logging.ClearProviders();
//builder.Logging.AddOpenTelemetry(logging =>
//{
//    logging.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("JaegerTracingDemo"));
//    logging.AddConsoleExporter(); // Also logs to console
//});

// Configure OpenTelemetry Tracing with Jaeger Exporter
Console.WriteLine("Host " + builder.Configuration["JAEGER_AGENT_HOST"]);
Console.WriteLine("Port " + builder.Configuration["JAEGER_AGENT_PORT"]);


builder.Services.AddOpenTelemetry()
    .WithTracing(tracerProviderBuilder =>
    {
        tracerProviderBuilder
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("C001_Jaegear"))
            .AddAspNetCoreInstrumentation()    // Enables tracing for ASP.NET Core requests
            .AddHttpClientInstrumentation()    // Enables tracing for HttpClient calls
            .AddJaegerExporter(options =>
            {
                options.AgentHost = builder.Configuration["JAEGER_AGENT_HOST"] ?? "jaeger"; // ✅ Use Jaeger service name
                options.AgentPort = int.Parse(builder.Configuration["JAEGER_AGENT_PORT"] ?? "6831"); // ✅ Default Jaeger UDP port
                //options.Endpoint = new Uri(builder.Configuration["JAEGER_AGENT_ENDPOINT"]);
            });
    });

//builder.Services.AddOpenTelemetry()
//    .WithTracing(tracerProviderBuilder =>
//    {
//        tracerProviderBuilder
//            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("C001_Jaegear"))
//            .AddAspNetCoreInstrumentation()    // Enables tracing for ASP.NET Core requests
//            .AddHttpClientInstrumentation()     // Enables tracing for HttpClient calls
//            .AddJaegerExporter(options =>
//            {
//                options.AgentHost = builder.Configuration["JAEGER_AGENT_HOST"] ?? "jaeger";
//                options.AgentPort = int.Parse(builder.Configuration["JAEGER_AGENT_PORT"]);
//                //options.AgentHost = "host.docker.internal"; // Jaeger host
//                //options.AgentHost = "localhost"; // Jaeger host
//                //options.AgentPort = 6831;        // Jaeger port (default is 6831)
//            });
    //});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
