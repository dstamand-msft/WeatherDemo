using WeatherDemo.DAL;

namespace WeatherDemoTests.Helpers;

public class Utilities
{
    public static void InitializeDbForTests(WeatherDemoDbContext db)
    {
        db.WeatherHistory.AddRange(GetSeedingData());
        db.SaveChanges();
    }

    public static List<WeatherHistory> GetSeedingData()
    {
        return new ()
        {
            new WeatherHistory
            {
                CityName = "London",
                Region = "City of London, Greater London",
                Country = "United Kingdom",
                TimeZoneId = "Europe/London",
                Date = new DateTime(2023,05,23),
                Latitude = 51.52,
                Longitude = -0.11,
                TemperatureC = 18
            },
            new WeatherHistory
            {
                CityName = "Montreal",
                Region = "Quebec",
                Country = "Canada",
                TimeZoneId = "America/Toronto",
                Date = new DateTime(2023,05,23),
                Latitude = 45.5,
                Longitude = -73.58,
                TemperatureC = 19
            },            
            new WeatherHistory
            {
                CityName = "Paris",
                Region = "Ile-de-France",
                Country = "France",
                TimeZoneId = "Europe/Paris",
                Date = new DateTime(2023,05,23),
                Latitude = 51.52,
                Longitude = 2.33,
                TemperatureC = 18
            },
        };
    }
}