
using AuthApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AuthApi.UnitTests
{
    public class AuthTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<ILogger<AccountController>> _mockLogger;

        public AuthTests()
        {
            _mockLogger = new Mock<ILogger<AccountController>>();
            _accountController = new AccountController(_mockLogger.Object);
        }

        [Fact]
        public void Get_Authorize_Empty_BadRequest()
        {
            // Arrange
            string client_id = string.Empty;
            string response_type = string.Empty;
            string redirect_uri = string.Empty;
            string scope = string.Empty;
            string state = string.Empty;

            var query = new[]
            {
                "client_id=test-client",
                "response_type=code",
                "redirect_uri=https://localhost/callback",
                "scope=openid profile",
                "state=xyz123"
            };

            // Act
            var result = _accountController.Authorize(
                client_id,
                response_type,
                redirect_uri,
                scope,
                state
                );

            // Assert
            var redirectResult = Assert.IsType<BadRequestObjectResult>(result); // This checks and casts safely
            Assert.Equal(400, redirectResult.StatusCode); // optional

        }


        [Fact]
        public void Get_Authorize_Empty_Success()
        {
            // Arrange
            string client_id = "test-client";
            string response_type = "code";
            string redirect_uri = "https://localhost/callback";
            string scope = "openid profile";
            string state = "xyz123";

            var query = new[]
            {
                "client_id=test-client",
                "response_type=code",
                "redirect_uri=https://localhost/callback",
                "scope=openid profile",
                "state=xyz123"
            };

            // Act
            var result = _accountController.Authorize(
                client_id,
                response_type,
                redirect_uri,
                scope,
                state
                );

            // Assert
            var redirectResult = Assert.IsType<RedirectResult>(result); // This checks and casts safely
            //https://localhost/callback?code=sample-code&state=xyz123

        }
    }
}
