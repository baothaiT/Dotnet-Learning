
using CS05_Template_Method_DesignPatterns.Services.AbstractClass;

namespace CS05_Template_Method_DesignPatterns.Services;
class ExcelReportGenerator : ReportGenerator
{
    // Override to provide specific implementation for Excel report formatting
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting report as an Excel file...");
    }

    // Use the default SaveReport method from base class (optional to override)
}