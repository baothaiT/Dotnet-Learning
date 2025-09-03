using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS004_SwaggerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
        }
    }
}
