using Microsoft.EntityFrameworkCore;

namespace NotificationScheduler.DataAccess.Models;

[Index(nameof(Location), IsUnique = true)]
public class Market
{
    public Guid Id { get; set; }
    public Location Location { get; set; }
    
    public List<Company> Companies { get; } = new();
}

public enum Location
{
    Denmark,
    Norway,
    Sweden,
    Finland
}