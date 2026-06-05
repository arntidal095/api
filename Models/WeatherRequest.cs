using System.ComponentModel.DataAnnotations;

namespace MyApi.Models;

/// <summary>
/// the date of the weather forcast
///  </summary>
public class WeatherRequest
{
    /// <summary>
    /// the date of the weather forcast.
    /// </summary>
   [Required]
   public DateOnly Date { get; set; }

   /// <summary>
   /// the city to grt yhe weather forcast for
   /// </summary>
   [Required]
   [StringLength(50, MinimumLength = 2)]
   public string City { get; set; } = string.Empty;
}