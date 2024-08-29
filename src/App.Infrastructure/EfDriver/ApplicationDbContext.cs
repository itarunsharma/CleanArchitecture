using App.Domain.Registration.Aggregates;
using App.Infrastructure.EfDriver.Configurations;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.EfDriver;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : DbContext(dbContextOptions)
{

    // DbSet for the Patient entity
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply configurations for the Client entity
        modelBuilder.ApplyConfiguration(new ClientConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
