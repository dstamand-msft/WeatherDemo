using WeatherDemo.Clients;
using WeatherDemo.Extensions;
using WeatherDemo.Models;

namespace WeatherDemo.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherAPIHttpClient _weatherApiHttpClient;

    public WeatherService(IWeatherAPIHttpClient weatherApiHttpClient)
    {
        _weatherApiHttpClient = weatherApiHttpClient;
    }

    public async Task<WeatherForecast> GetByCityAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("Value cannot be null, empty or whitespace", nameof(city));
        }

        var response = await _weatherApiHttpClient.GetByCityAsync(city);
        var forecast = new WeatherForecast
        {
            Country = response.Location.Country,
            Condition = response.Current.Condition.Text,
            Latitude = response.Location.Lat,
            Longitude = response.Location.Lon,
            CityName = response.Location.Name,
            Region = response.Location.Region,
            TemperatureC = response.Current.TempC,
            TemperatureFeelsLikeC = response.Current.FeelslikeC,
            TimeZoneId = response.Location.TzId,
            LastUpdated = response.Current.LastUpdatedEpoch.FromUnixTimeToLocalDateTime()
        };

        return forecast;
    }
}