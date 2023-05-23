using FluentAssertions;
using WeatherDemo;
using WeatherDemo.DAL;
using WeatherDemo.Models;
using WeatherDemoTests.Helpers;

namespace WeatherDemoTests.Controllers;

public class WeatherForecastControllerTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private readonly TestWebApplicationFactory<Program> _factory;
    private static readonly string BASE_URI = "/WeatherForecast";

    public WeatherForecastControllerTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;

        // Client that by default follows redirects
        _httpClient = _factory.CreateClient();
    }

    [Theory]
    [InlineData("Montreal")]
    public async Task get_city_from_history_should_return_the_expected_result(string city)
    {
        // Arrange

        // Act
        var act = await _httpClient.GetFromJsonAsync<WeatherAPIResponse>($"{BASE_URI}/history/{city}");

        // Assert
        var expected = new WeatherForecast();
        act.Should().BeEquivalentTo(expected);
    }
}