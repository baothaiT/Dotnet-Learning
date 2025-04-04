using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using OcelotApiGetways.Extensions;
using Serilog;
using Serilog.Events;
using System.Configuration;

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

Log.Information($"Start {builder.Environment.ApplicationName} up");

try
{
    Log.Information($"Starting up {builder.Environment.ApplicationName}");

    // Load configuration and services
    builder.Host.AddAppConfigurations();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.ConfigureOcelot(builder.Configuration);
    builder.Services.ConfigureCors(builder.Configuration);

    //builder.Services.AddSwaggerForOcelot(builder.Configuration);
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // CORS
    app.UseCors("CorsPolicy");

    // Routing
    app.UseRouting();
    app.UseHttpsRedirection();

    // Swagger for development
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.UseSwaggerForOcelotUI();
    }

    //app.UseEndpoints(endpoints =>
    //{
    //    endpoints.MapGet("/", context =>
    //    {
    //        // await context.Response.WriteAsync($"Hello TEDU members! This is {builder.Environment.ApplicationName}");
    //        context.Response.Redirect("swagger/index.html");
    //        return Task.CompletedTask;
    //    });
    //});

    //app.UseSwaggerForOcelotUI(
    //    opt =>
    //    {
    //        opt.PathToSwaggerGenerator = "/swagger/docs";
    //    });

    app.UseAuthorization();

    // Ocelot middleware must be before Run
    await app.UseOcelot();

    app.Run();
}
catch (Exception ex)
{
    if (ex.GetType().Name == "StopTheHostException") throw;
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information($"Shut down {builder.Environment.ApplicationName} complete");
    Log.CloseAndFlush();
}
