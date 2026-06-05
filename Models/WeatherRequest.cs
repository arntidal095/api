using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

/// <summary>
/// Represents a request for a weather forecast.
/// </summary>
public class WeatherRequest
{
    /// <summary>
    /// The date for which the weather forecast is requested.
    /// </summary>
    [Required]
    public DateOnly Date { get; set; }

    /// <summary>
    /// The city for which the weather forecast is requested.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string City { get; set; } = string.Empty;
}