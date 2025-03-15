using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C003_Gafana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }
    }
}
