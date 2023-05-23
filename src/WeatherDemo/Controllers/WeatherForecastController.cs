using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherDemo.DAL;
using WeatherDemo.Models;
using WeatherDemo.Services;

namespace WeatherDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly WeatherDemoDbContext _dbContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IWeatherService weatherService,
            WeatherDemoDbContext dbContext,
            ILogger<WeatherForecastController> logger)
        {
            _weatherService = weatherService;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("{city}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        public async Task<WeatherForecast> Get(string city)
        {
            _logger.LogInformation("Requesting city {City}", city);

            return await _weatherService.GetByCityAsync(city);
        }

        [HttpGet("history/{city}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetHistory(string city)
        {
            _logger.LogInformation("Requesting city {City}", city);

            var history = await _dbContext.WeatherHistory.FirstOrDefaultAsync(x => x.CityName == city);

            if (history == null)
            {
                return NotFound();
            }

            var res = new WeatherForecastHistory
            {
                CityName = history.CityName,
                Country = history.Country,
                Date = history.Date,
                Latitude = history.Latitude,
                Longitude = history.Longitude,
                Region = history.Region,
                TemperatureC = history.TemperatureC,
                TimeZoneId = history.TimeZoneId
            };

            return Ok(res);
        }
    }
}