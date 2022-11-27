using Microsoft.Extensions.Options;
using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Helpers.Settings;

namespace NotificationScheduler.Repository.Helpers;

public class ScheduleDatesResolver
{
    private readonly List<ScheduleSettings> settings;
    
    public ScheduleDatesResolver(IOptions<List<ScheduleSettings>> settings)
    {
        this.settings = settings.Value;
    }
    
    public List<DateTime> GetDates(Location marketLocation, CompanyType companyType)
    {
        var dates = new List<DateTime>();
        
        foreach (var setting in settings)
        {
            if (setting.MarketLocation == marketLocation && setting.CompanyTypes.Contains(companyType))
            {
                var now = DateTime.UtcNow.Date;
                foreach (var dayCount in setting.Days)
                {
                    dates.Add(now.AddDays(dayCount));
                }
            }
        }

        return dates;
    }
}