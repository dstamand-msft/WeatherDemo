using FluentAssertions;
using NSubstitute;
using WeatherDemo.Clients;
using WeatherDemo.Models;
using WeatherDemo.Services;

namespace WeatherDemoTests.Services;

public class WeatherServiceTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task getbycityasync_should_return_an_exception_when_city_is_null_empty_or_whitespace(string city)
    {
        // Arrange
        var sut = CreateWeatherService();

        // Act
        Func<Task> act = () => sut.GetByCityAsync(city);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task getbycityasync_should_return_the_expected_response_when_city_is_valid()
    {
        // Arrange
        var city = "Montreal";
        var country = "Canada";
        var temperatureInC = 5;
        var weatherCondition = "Sunny";

        var httpResponse = new WeatherAPIResponse
        {
            Current = new Current
            {
                TempC = temperatureInC,
                Condition = new Condition
                {
                    Text = weatherCondition
                },
                LastUpdatedEpoch = 1672531200
            },
            Location = new Location
            {
                Country = country,
                Name = city
            }
        };

        var httpClient = Substitute.For<IWeatherAPIHttpClient>();
        httpClient.GetByCityAsync(Arg.Any<string>()).ReturnsForAnyArgs(httpResponse);

        var sut = CreateWeatherService(httpClient);

        // Act
        var act = await sut.GetByCityAsync(city);

        // Assert
        var expected = new WeatherForecast
        {
            Country = country,
            CityName = city,
            TemperatureC = temperatureInC,
            Condition = weatherCondition,
            LastUpdated = new DateTime(2023, 01, 01, 0, 0, 0, DateTimeKind.Utc)
        };

        act.Should().BeEquivalentTo(expected);
    }

    private WeatherService CreateWeatherService(IWeatherAPIHttpClient weatherApiHttpClient = null)
    {
        return new WeatherService(weatherApiHttpClient ?? Substitute.For<IWeatherAPIHttpClient>());
    }
}