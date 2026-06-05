using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

public class WeatherForecast
{
    [Required]
    public DateOnly Date { get; set; }

    [Range(-20, 55)]
    public int TemperatureC { get; set; }

    [Required]
    [StringLength(20)]
    public string Summary { get; set; } = string.Empty;

    
}