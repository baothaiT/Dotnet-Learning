

using CS05_Template_Method_DesignPatterns.Services.AbstractClass;

namespace CS05_Template_Method_DesignPatterns.Services;

class PdfReportGenerator : ReportGenerator
{
    // Override to provide specific implementation for PDF report formatting
    protected override void FormatReport()
    {
        Console.WriteLine("Formatting report as a PDF...");
    }

    // Optionally override the saving mechanism
    protected override void SaveReport()
    {
        Console.WriteLine("Saving the PDF report to /documents/reports folder...");
    }
}