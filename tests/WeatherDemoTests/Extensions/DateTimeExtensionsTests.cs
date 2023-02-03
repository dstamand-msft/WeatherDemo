using FluentAssertions;
using WeatherDemo.Extensions;

namespace WeatherDemoTests.Extensions;

public class DateTimeExtensionsTests
{
    [Fact]
    public void fromunixtimetoutcdatetime_should_return_the_correct_datetime_instance_when_using_an_unix_timestamp()
    {
        // Arrange

        // 2023-01-01 00:00:00
        double timestamp = 1672549200;

        // Act
        var sut = timestamp.FromUnixTimeToUtcDateTime();

        // Assert
        var expected = new DateTime(2023, 01, 01, 5, 0, 0, DateTimeKind.Utc);
        sut.Should().Be(expected);
    }
}