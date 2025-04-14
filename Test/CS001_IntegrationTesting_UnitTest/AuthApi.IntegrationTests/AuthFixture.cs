using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthApi.IntegrationTests.Configuration;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Options;

namespace AuthApi.IntegrationTests
{
    public class AuthFixture : AccountApplicationFactory
    {
        //public DefaultOrganizationOptions DefaultOrganizationProvider => base.Services.GetRequiredService<IOptions<DefaultOrganizationOptions>>().Value;

        public const string Endpoint = "/connect/authorize";
        //public string ClientId = string.Empty;
        //public string ClientSecret = string.Empty;
        public HttpClient HttpClient => Server.CreateClient();


    }
}
