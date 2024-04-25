using Microsoft.EntityFrameworkCore;

namespace WeatherDemo.DAL;

public class WeatherDemoDbContext : DbContext
{
    public DbSet<WeatherHistory> WeatherHistory { get; set; }

    public WeatherDemoDbContext(DbContextOptions<WeatherDemoDbContext> options) : base(options)
    {
    }
}