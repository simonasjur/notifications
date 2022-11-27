using System.ComponentModel.DataAnnotations;
using NotificationScheduler.DataAccess.Models;

namespace NotificationScheduler.Repository.Dto;

public class CreateCompanyDto
{
    public string CompanyName { get; set; }
    
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Should contain 10 digits")]
    public string CompanyNumber { get; set; }
    public CompanyType CompanyType { get; set; }
    public Location Market { get; set; }
}
