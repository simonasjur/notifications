using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Repositories.Base;

namespace NotificationScheduler.Repository.Repositories.Interfaces;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<Notification> AddIfNotExistsAsync(DateTime sendingDate);
}