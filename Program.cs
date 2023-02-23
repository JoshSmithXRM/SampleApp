using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SampleDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetValue<string>("AppSettings:ConnectionString"));

            using (var dbContext = new SampleDbContext(optionsBuilder.Options))
            {
                // Add a new record to the database
                var newRecord = new Data
                {
                    Value = "Some Value"
                };
                dbContext.Data.Add(newRecord);
                dbContext.SaveChanges();

                // Query the database to verify that the record was inserted
                var query = from d in dbContext.Data
                            where d.Id == newRecord.Id
                            select d;

                var result = query.FirstOrDefault();

                if (result != null)
                {
                    Console.WriteLine($"Record added to database: {result.Id}, {result.Value}");
                }
                else
                {
                    Console.WriteLine("Failed to add record to database");
                }

                var totalRecordCount = dbContext.Data.Count();
                Console.WriteLine($"There are {totalRecordCount} records in the database.");
            }
        }
    }
}
