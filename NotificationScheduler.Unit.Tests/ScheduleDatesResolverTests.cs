using Microsoft.Extensions.Options;
using Moq;
using NotificationScheduler.DataAccess.Models;
using NotificationScheduler.Repository.Helpers;
using NotificationScheduler.Repository.Helpers.Settings;

namespace NotificationScheduler.Unit.Tests;

public class ScheduleDatesResolverTests
{
    private readonly Mock<IOptions<List<ScheduleSettings>>> scheduleSettings = new();
    
    [Fact]
    public void GetDates_CompanyTypeNoSettings_ReturnEmptyList()
    {
        var sut = CreateSut();
        var marketLocation = Location.Denmark;
        var companyType = CompanyType.Small;
        
        var dates = sut.GetDates(marketLocation, companyType);
        
        Assert.Empty(dates);
    }
    
    [Fact]
    public void GetDates_CompanyTypeWithSettings_ReturnDatesList()
    {
        var sut = CreateSut();
        var marketLocation = Location.Denmark;
        var companyType = CompanyType.Large;
        var now = DateTime.UtcNow.Date;
        var expectedList = new List<DateTime> { now.AddDays(1), now.AddDays(5), now.AddDays(10) };
        
        var dates = sut.GetDates(marketLocation, companyType);
        
        Assert.Equal(dates, expectedList);
    }
    
    private ScheduleDatesResolver CreateSut()
    {
        scheduleSettings.Setup(o => o.Value).Returns(new List<ScheduleSettings>
        {
            new()
            {
                MarketLocation = Location.Denmark,
                CompanyTypes = new List<CompanyType> { CompanyType.Large },
                Days = new List<int> { 1, 5, 10 }
            },
            new()
            {
                MarketLocation = Location.Finland,
                CompanyTypes = new List<CompanyType> { CompanyType.Small },
                Days = new List<int> { 1, 5, 10, 20 }
            }
        });
        return new ScheduleDatesResolver(scheduleSettings.Object);
    }
}