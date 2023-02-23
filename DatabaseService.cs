// See https://aka.ms/new-console-template for more information

// Interface for the API communication class
// Database class
using Microsoft.Extensions.Configuration;

public class DatabaseService : IDatabaseService
{
    private readonly IConfiguration _config;

    public DatabaseService(IConfiguration config)
    {
        _config = config;
    }

    public void SaveData(string data)
    {
        var connectionString = _config.GetValue<string>("AppSettings:ConnectionString");
        using (var context = new SampleDbContext(connectionString))
        {
            context.Data.Add(new Data { Value = data });
            context.SaveChanges();
        }
    }
}
