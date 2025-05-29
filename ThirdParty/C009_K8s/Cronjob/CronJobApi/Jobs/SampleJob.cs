using Quartz;

namespace CronJobApi.Jobs;

public class SampleJob : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Sample job ran at {DateTime.UtcNow} UTC");
        return Task.CompletedTask;
    }
}
