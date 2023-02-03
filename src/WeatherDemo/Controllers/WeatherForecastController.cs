using Microsoft.AspNetCore.Mvc;
using WeatherDemo.Models;
using WeatherDemo.Services;

namespace WeatherDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IWeatherService weatherService,
            ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet("{city}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public async Task<WeatherForecast> Get(string city)
        {
            return await _weatherService.GetByCityAsync(city);
        }
    }
}