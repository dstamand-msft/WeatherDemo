using System.ComponentModel.DataAnnotations;

namespace WeatherDemo.DAL;

public class WeatherHistory
{
    [Key]
    public long HistoryId { get; set; }

    public string CityName { get; set; }

    public string Region { get; set; }

    public string Country { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string TimeZoneId { get; set; }

    public DateTime Date { get; set; }

    public double TemperatureC { get; set; }
}