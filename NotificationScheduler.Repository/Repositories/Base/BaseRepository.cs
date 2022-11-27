using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NotificationScheduler.DataAccess;

namespace NotificationScheduler.Repository.Repositories.Base;

public class BaseRepository<TModel> : IBaseRepository<TModel>
    where TModel : class
{
    internal readonly NotificationsDbContext dbContext;
    private readonly DbSet<TModel> dbSet;

    public BaseRepository(NotificationsDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<TModel>();
    }

    public async Task<TModel> GetAsync(Guid id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TModel>> ListAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate)
    {
        return dbSet.Where(predicate);
    }

    public async Task<TModel> FirstAsync(Expression<Func<TModel, bool>> predicate)
    {
        return await dbSet.FirstAsync(predicate);
    }

    public async Task AddAsync(TModel entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Remove(TModel entity)
    {
        dbSet.Remove(entity);
    }

    public async Task<int> SaveAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}