using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Repositories.Base;

namespace NotificationScheduler.Repository.Repositories.Interfaces;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<Company> AddOrUpdateIfExistsAsync(Company companyModel);
}