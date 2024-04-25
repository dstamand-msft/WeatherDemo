namespace WeatherDemo.Models;

public abstract class WeatherForecastBase
{
    public string CityName { get; set; }

    public string Region { get; set; }

    public string Country { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string TimeZoneId { get; set; }

    public double TemperatureC { get; set; }

    public double TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}