using FluentAssertions;
using WeatherDemo.Extensions;

namespace WeatherDemoTests.Extensions;

public class DateTimeExtensionsTests
{
    [Fact]
    public void fromunixtimetolocaldatetime_should_return_the_correct_datetime_instance_when_using_an_unix_timestamp()
    {
        // Arrange

        // 2023-01-01 00:00:00
        double timestamp = 1672549200;

        // Act
        var sut = timestamp.FromUnixTimeToLocalDateTime();

        // Assert
        var expected = new DateTime(2023, 01, 01, 0, 0, 0, DateTimeKind.Local);
        sut.Should().Be(expected);
    }
}