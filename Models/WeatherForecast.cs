using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

/// <summary>
/// Represents a weather forecast for a specific date, temperature, and summary.
/// </summary>
    public class WeatherForecast

{
    ///<summary>the forcast data.</summary>
    [Required]
    public DateOnly Date { get; set; }

    ///<summary>the temperature in celsius.</summary>
    [Range(-20, 55)]
    public int TemperatureC { get; set; }
    ///<summary>the summary of the weather.</summary>
    [Required]
    [StringLength(20)]
    public string Summary { get; set; } = string.Empty;

    
}