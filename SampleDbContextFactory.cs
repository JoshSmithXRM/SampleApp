// See https://aka.ms/new-console-template for more information

// Interface for the API communication class
// Database class
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class SampleDbContextFactory : IDesignTimeDbContextFactory<SampleDbContext>
{
    public SampleDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<SampleDbContext>();
        var connectionString = configuration.GetValue<string>("AppSettings:ConnectionString");
        builder.UseSqlServer(connectionString);

        return new SampleDbContext(builder.Options);
    }
}
