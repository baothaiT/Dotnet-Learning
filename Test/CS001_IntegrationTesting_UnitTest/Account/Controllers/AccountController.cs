using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("connect")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet("authorize")]
        public IActionResult Authorize(
        [FromQuery] string client_id,
        [FromQuery] string response_type,
        [FromQuery] string redirect_uri,
        [FromQuery] string scope,
        [FromQuery] string state)
        {
            if (string.IsNullOrEmpty(client_id) || string.IsNullOrEmpty(redirect_uri))
                return BadRequest("Missing required parameters.");

            // Simulate redirect with code
            var redirectUrl = $"{redirect_uri}?code=sample-code&state={state}";
            return Ok(redirectUrl);
        }
    }
}
