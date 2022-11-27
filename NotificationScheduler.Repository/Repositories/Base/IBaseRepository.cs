using System.Linq.Expressions;

namespace NotificationScheduler.Repository.Repositories.Base;

public interface IBaseRepository<TModel> where TModel : class
{
    Task<TModel> GetAsync(Guid id);
    Task<IEnumerable<TModel>> ListAllAsync();
    IEnumerable<TModel> Find(Expression<Func<TModel, bool>> predicate);
    Task<TModel> FirstAsync(Expression<Func<TModel, bool>> predicate);
    Task AddAsync(TModel entity);
    void Remove(TModel entity);
    Task<int> SaveAsync();
}