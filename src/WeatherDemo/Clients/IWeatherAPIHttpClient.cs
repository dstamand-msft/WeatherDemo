using WeatherDemo.Models;

namespace WeatherDemo.Clients;

public interface IWeatherAPIHttpClient
{
    Task<WeatherAPIResponse> GetByCityAsync(string city);
}