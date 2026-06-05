using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers;

/// <summary>
/// Handles weather forecast endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool",
        "Mild", "Warm", "Balmy", "Hot",
        "Sweltering", "Scorching"
    };

/// <summary>
///     Gets aa 5-day weather forecast for a given city and date.
/// </summary>
/// <returns>List of weather forecasts</returns>
    [HttpGet("request")]
    public IActionResult GetWeather()
    {
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        return Ok(forecast);
    }

/// <summary>
///     Gets the weather for a specific city and date.
/// </summary>
/// <param name="forecast">city and date.</param>
/// <returns>weather forecast</returns>
/// <response code="200">Returns the weather forecast</response>
/// <response code="400">If the request is invalid</response>
    [HttpGet("datey")]
    public IActionResult GetDate()
    {
        return Ok(DateOnly.FromDateTime(DateTime.Now));
    }



[HttpPost]
public IActionResult GetWeatherByCity([FromBody] WeatherRequest request)
{
   if (!ModelState.IsValid)
   {
       return BadRequest(ModelState);
   }
   return Ok(new
   {
       request.City,
       request.Date,
       Temperature = Random.Shared.Next(-20, 55),
       Summary = "Sunny"
   });
}
}