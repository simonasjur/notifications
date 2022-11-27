using Microsoft.EntityFrameworkCore;
using NotificationScheduler.DataAccess;
using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Repositories.Base;
using NotificationScheduler.Repository.Repositories.Interfaces;

namespace NotificationScheduler.Repository.Repositories;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    public CompanyRepository(NotificationsDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<Company> AddOrUpdateIfExistsAsync(Company companyModel)
    {
        var company = await dbContext.Companies
            .Include(c => c.Markets)
            .Include(c => c.Notifications)
            .FirstOrDefaultAsync(c => c.Number == companyModel.Number);

        if (company != null)
        {
            company.Name = companyModel.Name;
            company.Type = companyModel.Type;
            return company;
        }
        
        await dbContext.AddAsync(companyModel);
        return companyModel;
    }
}
