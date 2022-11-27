using Microsoft.EntityFrameworkCore;

namespace NotificationScheduler.DataAccess.Models;

[Index(nameof(SendingDate), IsUnique = true)]
public class Notification
{
    public Guid Id { get; set; }
    public DateTime SendingDate { get; set; }
    
    public List<Company> Companies { get; } = new();
}