using WeatherDemo.Models;

namespace WeatherDemo.Clients;

public class WeatherAPIHttpClient : IWeatherAPIHttpClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public WeatherAPIHttpClient(string apiKey, HttpClient httpClient)
    {
        _apiKey = apiKey;
        _httpClient = httpClient;
    }

    public async Task<WeatherAPIResponse> GetByCityAsync(string city)
    {
        var response = await _httpClient.GetFromJsonAsync<WeatherAPIResponse>($"https://api.weatherapi.com/v1/current.json?key={_apiKey}&q={city}&aqi=no");
        return response;
    }
}