
namespace CS05_Template_Method_DesignPatterns.Services.AbstractClass;

abstract class ReportGenerator
{
    // Template method
    public void GenerateReport()
    {
        CollectData();
        FormatReport();
        SaveReport();
    }

    // Common method for collecting data (same for all subclasses)
    protected void CollectData()
    {
        Console.WriteLine("Collecting data for the report...");
    }

    // Abstract method to be implemented by subclasses
    protected abstract void FormatReport();

    // Hook method that can be optionally overridden by subclasses
    protected virtual void SaveReport()
    {
        Console.WriteLine("Saving the report to a default location...");
    }
}