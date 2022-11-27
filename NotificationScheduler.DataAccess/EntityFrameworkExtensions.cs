using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationScheduler.DataAccess;

public static class EntityFrameworkExtensions
{
    public static void AddEntityFramework(this IServiceCollection services, Action<EntityFrameworkSettings> settings)
    {
        var configuration = new EntityFrameworkSettings();
        settings.Invoke(configuration);
        services.Configure(settings);

        services.AddDbContext<NotificationsDbContext>(
            options => options.UseSqlite(configuration.DataLayerDefault,
                    x => x.MigrationsHistoryTable("MigrationNotifications")));
    }
    
    public static void RunDatabaseMigrations(this WebApplication app)
    {
        var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<NotificationsDbContext>();

        if (db.Database.IsRelational())
        {
            db.Database.Migrate();
        }
    }
}