using NotificationScheduler.DataAccess.Models;

namespace NotificationScheduler.Repository.Helpers.Settings;

public class ScheduleSettings
{
    public const string Position = "ScheduleSettings";
        
    public Location MarketLocation { get; set; }
    public List<int> Days { get; set; }
    public List<CompanyType> CompanyTypes { get; set; }
}