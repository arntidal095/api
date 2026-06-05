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

    private static readonly string[] ValidCities =
    {
        "Lagos",
        "Abuja",
        "Ibadan",
        "Port Harcourt",
        "Kano"
    };

    /// <summary>
    /// Gets a 5-day weather forecast.
    /// </summary>
    /// <returns>List of weather forecasts.</returns>
    [HttpGet]
    public IActionResult GetWeather()
    {
        var forecast = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        return Ok(forecast);
    }

    /// <summary>
    /// Gets today's date.
    /// </summary>
    /// <returns>The current date.</returns>
    [HttpGet("date")]
    public IActionResult GetDate()
    {
        return Ok(DateOnly.FromDateTime(DateTime.Now));
    }

    /// <summary>
    /// Gets a weather forecast for a specified city and date.
    /// </summary>
    /// <param name="request">The weather request containing city and date.</param>
    /// <returns>A weather forecast.</returns>
    /// <response code="200">Returns the weather forecast.</response>
    /// <response code="400">If the request is invalid.</response>
    [HttpPost("forecast")]
    public IActionResult GetForecast([FromBody] WeatherRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!ValidCities.Contains(request.City, StringComparer.OrdinalIgnoreCase))
        {
            return BadRequest("Invalid city.");
        }

        var today = DateOnly.FromDateTime(DateTime.Today);

        if (request.Date < today)
        {
            return BadRequest("Date cannot be in the past.");
        }

        if (request.Date > today.AddDays(30))
        {
            return BadRequest("Date cannot be more than 30 days in the future.");
        }

        var forecast = new WeatherForecast
        {
            Date = request.Date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };

        return Ok(forecast);
    }
}