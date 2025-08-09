using System;
using System.Runtime.CompilerServices;
using CS004_SwaggerUI.EventHandler;
using CS004_SwaggerUI.Events;
using CS004_SwaggerUI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CS004_SwaggerUI.Config;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDB(this IServiceCollection service, WebApplicationBuilder builder)
    {
        // Add DbContext
        service.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDb")));
        return service;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection service)
    {
        // Add Swagger and Controllers
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();
        service.AddControllers();

        // Register repositories
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddSingleton<IEventDispatcher, EventDispatcher>();
        service.AddSingleton<IEventHandler<AccountStatusEvent>, AccountStatusEventHandler>();

        return service;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection service)
    {
        // Register repositories
        service.AddScoped<IUserRepository, UserRepository>();
        
        return service;
    }

    public static IServiceCollection ConfigureEventHandlers(this IServiceCollection service)
    {
        // Register event handlers
        service.AddSingleton<IEventDispatcher, EventDispatcher>();
        service.AddSingleton<IEventHandler<AccountStatusEvent>, AccountStatusEventHandler>();

        return service;
    }
}
