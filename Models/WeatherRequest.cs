using System.ComponentModel.DataAnnotations;
namespace MyApi.Models;
public class WeatherRequest
{
   [Required]
   public DateOnly Date { get; set; }
   [Required]
   [StringLength(50, MinimumLength = 2)]
   public string City { get; set; } = string.Empty;
}