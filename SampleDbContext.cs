// See https://aka.ms/new-console-template for more information

// Interface for the API communication class
// Database class
using Microsoft.EntityFrameworkCore;

public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    public SampleDbContext(string connectionString) : base(GetOptions(connectionString))
    {
    }

    private static DbContextOptions<SampleDbContext> GetOptions(string connectionString)
    {
        return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SampleDbContext>(), connectionString).Options;
    }

    public DbSet<Data> Data { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Data>(entity =>
        {
            entity.ToTable("Data");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Value).IsRequired();
        });
    }
}