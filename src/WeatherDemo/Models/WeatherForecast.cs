namespace WeatherDemo.Models;

public class WeatherForecast : WeatherForecastBase
{
    public DateTime LastUpdated { get; set; }

    public string Condition { get; set; }

    public double TemperatureFeelsLikeC { get; set; }

    public double TemperatureFeelsLikeF => 32 + (int)(TemperatureFeelsLikeC / 0.5556);
}