using System;

namespace CS007_Hangfire.Services;

public class TestJobService
{
    public void SendEmail()
    {
        Console.WriteLine($"[SendEmail] Email sent at {DateTime.Now}");
    }
}
