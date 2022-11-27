using Microsoft.EntityFrameworkCore;
using NotificationScheduler.DataAccess;
using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Repositories.Base;
using NotificationScheduler.Repository.Repositories.Interfaces;

namespace NotificationScheduler.Repository.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(NotificationsDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<Notification> AddIfNotExistsAsync(DateTime sendingDate)
    {
        var notification = await dbContext.Notifications.FirstOrDefaultAsync(n => n.SendingDate == sendingDate);

        if (notification == null)
        {
            notification = new Notification { SendingDate = sendingDate };
            await dbContext.AddAsync(notification);
        }

        return notification;
    }
}