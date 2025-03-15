using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly ActivitySource ActivitySource = new("MyJaegerApp");
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var test = new
        {
            name = "test",
            id = "test"
        };

        // Serialize request to JSON
        string jsonRequest = JsonSerializer.Serialize(test, new JsonSerializerOptions { WriteIndented = true });

        using (var activity = ActivitySource.StartActivity("GetWeatherForecast1"))
        {
            activity?.SetTag("custom-tag", "weather-forecast");
            activity?.SetTag("request.city", "weather-forecast");
            activity?.SetTag("request.units", "weather-forecast");

            // Add JSON request as an event
            activity?.AddEvent(new ActivityEvent("Received JSON request", tags: new ActivityTagsCollection
            {
                { "request.json", jsonRequest }
            }));

            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
            string jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });


            _logger.LogInformation("Returning response: {@Response}", response);
            activity?.SetTag("response.temperature", "response.TemperatureC");
            // Add JSON response as an event
            activity?.AddEvent(new ActivityEvent("Returning JSON response", tags: new ActivityTagsCollection
            {
                { "response.json", jsonResponse }
            }));


            return response;
        }
            
    }
}
