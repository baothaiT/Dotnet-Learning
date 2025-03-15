using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace C001_Jaegear.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly ActivitySource _activitySource;
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(
            ActivitySource activitySource,
            ILogger<ExampleController> logger
            )
        {
            _activitySource = activitySource;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching weather data...");
            using var activity = _activitySource.StartActivity("GetWeatherData");

            activity?.SetTag("method", "GET");
            activity?.SetTag("controller", "WeatherController");
            activity?.SetTag("status", "success1");
            // Example traceable endpoint

            activity?.AddEvent(new ActivityEvent("Fetched weather data"));
            return Ok("Hello from Jaeger traced endpoint!");
        }
    }
}
