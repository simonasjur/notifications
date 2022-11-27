using Microsoft.AspNetCore.Mvc;
using NotificationScheduler.Repository.Dto;
using NotificationScheduler.Repository.UnitsOfWork;

namespace NotificationScheduler.Controllers;

[ApiController]
[Route("notifications")]
public class NotificationController : ControllerBase
{
    private readonly NotificationUnitOfWork notificationUnitOfWork;
    
    public NotificationController(NotificationUnitOfWork notificationUnitOfWork)
    {
        this.notificationUnitOfWork = notificationUnitOfWork;
    }
    
    [HttpPost("schedule")]
    public async Task<ActionResult<GetScheduleDto>> CreateSchedule(CreateCompanyDto createCompanyDto)
    {
        return Ok(await notificationUnitOfWork.CreateScheduleAsync(createCompanyDto));
    }
}