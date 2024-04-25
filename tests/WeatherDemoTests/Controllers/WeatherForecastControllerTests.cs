using FluentAssertions;
using WeatherDemo;
using WeatherDemo.Models;

namespace WeatherDemoTests.Controllers;

public class WeatherForecastControllerTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private static readonly string BASE_URI = "/WeatherForecast";

    public WeatherForecastControllerTests(TestWebApplicationFactory<Program> factory)
    {
        // Client that by default follows redirects
        _httpClient = factory.CreateClient();
    }

    [Theory("Integration")]
    [InlineData("Montreal")]
    [Trait("Category", "Integration")]
    public async Task get_city_from_history_should_return_the_expected_result(string city)
    {
        // Act
        var act = await _httpClient.GetFromJsonAsync<WeatherForecastHistory>($"{BASE_URI}/history/{city}");

        // Assert
        var expected = new WeatherForecastHistory
        {
            CityName = "Montreal",
            Region = "Quebec",
            Country = "Canada",
            TimeZoneId = "America/Toronto",
            Date = new DateTime(2023, 05, 23),
            Latitude = 45.5,
            Longitude = -73.58,
            TemperatureC = 19
        };
        act.Should().BeEquivalentTo(expected);
    }
}