using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NotificationScheduler.DataAccess.Models;

[Index(nameof(Number), IsUnique = true)]
public class Company
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public CompanyType Type { get; set; }

    public List<Notification> Notifications { get; } = new();
    public List<Market> Markets { get; } = new();
}

public enum CompanyType
{
    Small,
    Medium,
    Large
}

