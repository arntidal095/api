using MyApi.Models;
using System.ComponentModel.DataAnnotations;
namespace MyApi.Services;


/// <summary>
/// Provides weather-related business logic such as generating forecasts.
/// Acts as the service layer between controllers and data logic.
/// </summary>
public class WeatherService
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool",
        "Mild", "Warm", "Balmy", "Hot",
        "Sweltering", "Scorching"
    };

    /// <summary>
    /// Generates a 5-day weather forecast.
    /// </summary>
    public List<WeatherForecast> Get5DayForecast()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = GetRandomSummary(),
                Message = "success"
            })
            .ToList();
    }

    /// <summary>
    /// Generates a single-day forecast for a given date.
    /// </summary>
    public WeatherForecast GenerateForecast(DateOnly date)
    {
        return new WeatherForecast
        {
            Date = date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = GetRandomSummary(),
            Message = "success"
        };
    }

    /// <summary>
    /// Picks a random weather summary.
    /// </summary>
    private string GetRandomSummary()
    {
        return Summaries[Random.Shared.Next(Summaries.Length)];
    }
}
/// <summary>
/// Represents a request for a weather forecast.
/// </summary>
public class WeatherRequest
{
    [Required]
    public DateOnly Date { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string City { get; set; } = string.Empty;
}