using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers;

/// <summary>
/// Handles weather forecast endpoints.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    private static readonly string[] ValidCities =
    {
        "Lagos",
        "Abuja",
        "Ibadan",
        "Port Harcourt",
        "Kano"
    };

    private readonly ILogger<WeatherController> _logger;

public WeatherController(
    WeatherService weatherService,
    ILogger<WeatherController> logger)
{
    _weatherService = weatherService;
    _logger = logger;
}

    /// <summary>
    /// Gets a 5-day weather forecast.
    /// </summary>
    [HttpGet]
    public IActionResult GetWeather()
    {
        _logger.LogInformation("GetWeather endpoint called");
        
        try
        {
            throw new Exception("Sample exception outside try-catch");
            var forecast = _weatherService.Get5DayForecast();

            return Ok(new ApiResponse<List<WeatherForecast>>
            {
                Success = true,
                Message = "Forecast retrieved successfully",
                Data = forecast
            });
        }
        catch (Exception)
        {
            _logger.LogError("An error occurred while retrieving weather forecast.");
            return StatusCode(500, new ApiResponse<object>
            {
                Success = false,
                Message = "Something went wrong",
                Data = null
            });
        }
    }

    /// <summary>
    /// Gets today's date.
    /// </summary>
    [HttpGet("date")]
    public IActionResult GetDate()
    {
        return Ok(new ApiResponse<string>
        {
            Success = true,
            Message = "Date retrieved",
            Data = DateOnly.FromDateTime(DateTime.Now).ToString()
        });
    }

    /// <summary>
    /// Gets a weather forecast for a specified city and date.
    /// </summary>
    [HttpPost("forecast")]
    public IActionResult GetForecast([FromBody] WeatherRequest request)
    {

        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Invalid request data",
                    Data = ModelState
                });
            }

            if (!ValidCities.Contains(request.City, StringComparer.OrdinalIgnoreCase))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Invalid city",
                    Data = null
                });
            }

            var today = DateOnly.FromDateTime(DateTime.Today);

            if (request.Date < today)
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Date cannot be in the past",
                    Data = null
                });
            }

            if (request.Date > today.AddDays(30))
            {
                return BadRequest(new ApiResponse<object>
                {
                    Success = false,
                    Message = "Date cannot be more than 30 days ahead",
                    Data = null
                });
            }

            var forecast = _weatherService.GenerateForecast(request.Date);

            return Ok(new ApiResponse<WeatherForecast>
            {
                Success = true,
                Message = "Forecast generated successfully",
                Data = forecast
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new ApiResponse<object>
            {
                Success = false,
                Message = "Unexpected server error",
                Data = null
            });
        }
    }
}