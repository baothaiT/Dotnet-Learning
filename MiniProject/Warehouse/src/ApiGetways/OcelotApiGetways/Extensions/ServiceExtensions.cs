using Ocelot.DependencyInjection;
using Ocelot.Provider.Polly;

namespace OcelotApiGetways.Extensions
{
    public static class ServiceExtensions
    {
        internal static IServiceCollection AddConfigurationSettings(this IServiceCollection services,
        IConfiguration configuration)
        {
            //var jwtSettings = configuration.GetSection(nameof(JwtSettings))
            //    .Get<JwtSettings>();
            //services.AddSingleton(jwtSettings);

            //var apiConfiguration = configuration.GetSection(nameof(ApiConfiguration))
            //    .Get<ApiConfiguration>();
            //services.AddSingleton(apiConfiguration);

            return services;
        }
        public static void ConfigureOcelot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOcelot(configuration);
            //.AddPolly();
            //.AddCacheManager(x => x.WithDictionaryHandle());
            //services.AddTransient<ITokenService, TokenService>();
            // services.AddJwtAuthentication();
            
        }

        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration["AllowOrigins"];
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", buider =>
                {
                    buider.WithOrigins("AllowOrigins")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("x-pagination");
                });
            });
        }
    }
}
