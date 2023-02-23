using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // Register services
                services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build());
                services.AddHttpClient<IApiService, ApiService>();
                services.AddSingleton<IDatabaseService, DatabaseService>();
                services.AddTransient<DataCoordinator>();

                // Register the application entry point
                services.AddTransient<App>();
            });

        var host = builder.Build();
        using (var serviceScope = host.Services.CreateScope())
        {
            var serviceProvider = serviceScope.ServiceProvider;
            var app = serviceProvider.GetRequiredService<App>();
            await app.RunAsync();
        }

        Console.WriteLine("Program completed, exiting.");
    }
}