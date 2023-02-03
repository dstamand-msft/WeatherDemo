﻿namespace WeatherDemo.Models;

public class WeatherForecast
{
    public string CityName { get; set; }

    public string Region { get; set; }

    public string Country { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string TimeZoneId { get; set; }

    public DateTime LastUpdated { get; set; }

    public string Condition { get; set; }

    public double TemperatureC { get; set; }

    public double TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public double TemperatureFeelsLikeC { get; set; }

    public double TemperatureFeelsLikeF => 32 + (int)(TemperatureFeelsLikeC / 0.5556);
}