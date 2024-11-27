using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("This is a public endpoint.");
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult UserEndpoint()
        {
            return Ok("This endpoint is for authenticated users.");
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndpoint()
        {
            return Ok("This endpoint is for admin users only.");
        }
    }
}
