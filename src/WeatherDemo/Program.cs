using Microsoft.Extensions.Options;
using WeatherDemo.Clients;
using WeatherDemo.Services;

namespace WeatherDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IWeatherService, WeatherService>();
            builder.Services.AddOptions<WeatherAPIOptions>().Configure<IConfiguration>((options, configuration) =>
            {
                options.APIKey = configuration.GetValue<string>("WeatherAPIKey");
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient<IWeatherAPIHttpClient,WeatherAPIHttpClient>((client, provider) => new WeatherAPIHttpClient(provider.GetRequiredService<IOptions<WeatherAPIOptions>>().Value.APIKey, client));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}