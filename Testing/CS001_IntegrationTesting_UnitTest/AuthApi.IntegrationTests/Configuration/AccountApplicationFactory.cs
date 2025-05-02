using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using AuthApi;
namespace AuthApi.IntegrationTests.Configuration
{
    public class AccountApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //// Remove the app's real DB context registration
                //var descriptor = services.SingleOrDefault(
                //    d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                //if (descriptor != null)
                //    services.Remove(descriptor);

                //// Add a test DB context using InMemory or a test container
                //services.AddDbContext<AppDbContext>(options =>
                //{
                //    options.UseInMemoryDatabase("TestDb");
                //});

                //// Optionally override other dependencies
                //services.AddScoped<IMyService, FakeMyService>();
            });
        }
    }
}
