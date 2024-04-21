using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCronJob.Domain.Entities;

namespace MyCronJob.Infrastructure.SqlServer
{
  public class SqlServerDbContext : DbContext
  {
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
      public SqlServerDbContext CreateDbContext(string[] args)
      {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<SqlServerDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new SqlServerDbContext(configuration);
      }
    }
    private readonly IConfiguration _configuration;

    public SqlServerDbContext(IConfiguration configuration) : base()
    {
      _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
      }
    }

    public DbSet<User> User { get; set; }

  }
}