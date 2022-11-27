using System.Globalization;
using NotificationScheduler.Repository.Dto;
using NotificationScheduler.Repository.Helpers;
using NotificationScheduler.Repository.Helpers.Converters;
using NotificationScheduler.Repository.Repositories.Interfaces;

namespace NotificationScheduler.Repository.UnitsOfWork;

public class NotificationUnitOfWork
{
    private readonly ICompanyRepository companyRepository;
    private readonly IMarketRepository marketRepository;
    private readonly INotificationRepository notificationRepository;
    private readonly ScheduleDatesResolver scheduleDatesResolver;

    public NotificationUnitOfWork(ICompanyRepository companyRepository, IMarketRepository marketRepository,
        INotificationRepository notificationRepository, ScheduleDatesResolver scheduleDatesResolver)
    {
        this.companyRepository = companyRepository;
        this.marketRepository = marketRepository;
        this.notificationRepository = notificationRepository;
        this.scheduleDatesResolver = scheduleDatesResolver;
    }
    
    public async Task<GetScheduleDto> CreateScheduleAsync(CreateCompanyDto createCompanyDto)
    {
        var company = await companyRepository.AddOrUpdateIfExistsAsync(CompanyConverter.ToModel(createCompanyDto));

        var market = await marketRepository.FirstAsync(m => m.Location == createCompanyDto.Market);
        if (company.Markets.All(m => m.Id != market.Id))
        {
            company.Markets.Add(market);
        }

        var dates = scheduleDatesResolver.GetDates(market.Location, company.Type);
        foreach (var date in dates)
        {
            var notification = await notificationRepository.AddIfNotExistsAsync(date);
            if (company.Notifications.All(n => n.Id != notification.Id))
            {
                company.Notifications.Add(notification);
            }
        }
        
        await notificationRepository.SaveAsync();

        return new GetScheduleDto
        {
            CompanyId = company.Id,
            Notifications =  dates.Select(d => d.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
        };
    }
}