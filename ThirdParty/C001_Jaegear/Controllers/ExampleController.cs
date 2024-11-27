using Microsoft.AspNetCore.Mvc;

namespace C001_Jaegear.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // Example traceable endpoint
            return Ok("Hello from Jaeger traced endpoint!");
        }
    }
}
