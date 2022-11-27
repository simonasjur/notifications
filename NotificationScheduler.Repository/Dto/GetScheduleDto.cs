namespace NotificationScheduler.Repository.Dto;

public class GetScheduleDto
{
    public Guid CompanyId { get; set; }
    public IEnumerable<string> Notifications { get; set; }
}