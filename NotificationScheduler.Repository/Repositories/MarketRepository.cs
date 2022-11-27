using NotificationScheduler.DataAccess;
using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Repositories.Base;
using NotificationScheduler.Repository.Repositories.Interfaces;

namespace NotificationScheduler.Repository.Repositories;

public class MarketRepository : BaseRepository<Market>, IMarketRepository
{
    public MarketRepository(NotificationsDbContext dbContext) : base(dbContext)
    {
    }
}