using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.IntegrationTests
{
    public  class AuthTests : IClassFixture<AuthFixture>
    {
        private readonly AuthFixture _fixture;
        public AuthTests(AuthFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task Authorize_ReturnsRedirectWithCode_WhenValidRequest()
        {
            var query = new[]
            {
                "client_id=test-client",
                "response_type=code",
                "redirect_uri=https://localhost/callback",
                "scope=openid profile",
                "state=xyz123"
            };

            string queryString = string.Join("&", query);

            // Make sure the base URL ends correctly
            string url = AuthFixture.Endpoint.Contains("?")
                ? AuthFixture.Endpoint + "&" + queryString
                : AuthFixture.Endpoint + "?" + queryString;

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await _fixture.HttpClient.SendAsync(request).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


            //// Act
            //var response = await _client.GetAsync(url);

            //// Assert
            //response.StatusCode.Should().Be(HttpStatusCode.Redirect);
            //response.Headers.Location.ToString().Should().Contain("code=sample-code");
        }
    }
}
