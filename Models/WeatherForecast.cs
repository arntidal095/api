using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

/// <summary>
/// Represents a weather forecast for a specific date,
/// temperature, and weather summary.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// The date of the forecast.
    /// </summary>
    [Required]
    public DateOnly Date { get; set; }

    /// <summary>
    /// The temperature in degrees Celsius.
    /// </summary>
    [Range(-20, 55)]
    public int TemperatureC { get; set; }

    /// <summary>
    /// A short description of the weather conditions.
    /// </summary>
    [Required]
    [StringLength(20)]
    public string Summary { get; set; } = string.Empty;
}