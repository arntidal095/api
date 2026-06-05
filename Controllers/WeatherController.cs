using Microsoft.AspNetCore.Mvc;
using MyApi.Models;

namespace MyApi.Controllers;

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

    [HttpGet("datey")]
    public IActionResult GetDate()
    {
        return Ok(DateOnly.FromDateTime(DateTime.Now));
    }

    [HttpPost]
public IActionResult CreateWeatherForecast(WeatherForecast forecast)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    return Ok(forecast);
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