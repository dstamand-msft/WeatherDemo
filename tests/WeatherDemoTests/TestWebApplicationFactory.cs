using Microsoft.AspNetCore.Mvc.Testing;
using WeatherDemo.DAL;

namespace WeatherDemoTests;

public class TestWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureServices(services =>
        {
            var sp = services.BuildServiceProvider();
            
            // executed for every test class the factory is injected into!
            // use a pre-seeded DB if you want to have more control.

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<WeatherDemoDbContext>();

                //var config = scopedServices.GetRequiredService<IConfiguration>();
                //var dbConfig = config.GetConnectionString("Db");

                // do more checks if EF is responsible to create the db/tables i.e. via db.Database.EnsuredDeleted/Created.
                //WeatherDemoTests.Helpers.Utilities.InitializeDbForTests(db);
            }
        });
    }
}