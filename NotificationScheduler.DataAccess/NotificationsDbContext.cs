using Microsoft.EntityFrameworkCore;
using NotificationScheduler.DataAccess.Models;

namespace NotificationScheduler.DataAccess;

public class NotificationsDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Market> Markets { get; set; }
    
    public NotificationsDbContext(DbContextOptions<NotificationsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Market>().HasData(
            new Market { Id = new Guid("74bdbf46-1c5d-47ab-9da0-b60ab8f07605"), Location = Location.Denmark },
            new Market { Id = new Guid("9cd11347-465b-4eb5-a4d5-a9d6b9afc425"), Location = Location.Finland },
            new Market { Id = new Guid("128d9dfa-860c-43b3-a1b6-4b41c0e9e668"), Location = Location.Norway },
            new Market { Id = new Guid("bd418e29-19cf-4cbb-a7d8-51d4285ed850"), Location = Location.Sweden });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties(typeof(Enum))
            .HaveConversion<string>();
    }
}