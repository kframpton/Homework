using DataEntities.Entities.Tardis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataEntities.Contexts;
public class TardisContext : DbContext
{
    protected readonly IConfiguration configuration;
    protected readonly ILoggerFactory loggerFactory;

    public TardisContext(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        this.configuration = configuration;
        this.loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(configuration.GetConnectionString("Tardis"));
        options.UseLoggerFactory(loggerFactory);
    }

    public DbSet<Module> Modules { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonHistory> PeopleHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        ArgumentNullException.ThrowIfNull(mb, nameof(mb));
    }
}
