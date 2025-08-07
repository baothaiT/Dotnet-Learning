using CS007_Hangfire.Services;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS007_Hangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
{
    private readonly TestJobService _jobService;

    public JobsController(TestJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpPost("enqueue")]
    public IActionResult EnqueueJob()
    {
        BackgroundJob.Enqueue(() => _jobService.SendEmail());
        return Ok("Job enqueued");
    }

    [HttpPost("schedule")]
    public IActionResult ScheduleJob()
    {
        BackgroundJob.Schedule(() => _jobService.SendEmail(), TimeSpan.FromSeconds(30));
        return Ok("Job scheduled");
    }

    [HttpPost("recurring")]
    public IActionResult CreateRecurringJob()
    {
        RecurringJob.AddOrUpdate("email-job", () => _jobService.SendEmail(), Cron.Minutely);
        return Ok("Recurring job created");
    }
}
}
