using WeatherDemo.Models;

namespace WeatherDemo.Services;

public interface IWeatherService
{
    Task<WeatherForecast> GetByCityAsync(string city);
}