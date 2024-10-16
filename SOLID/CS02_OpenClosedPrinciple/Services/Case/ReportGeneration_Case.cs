namespace OpenClosedPrinciple.Services.Case;

public class ReportGeneration_Case
{
    /// <summary>
    /// Case for Open Close Principle
    /// </summary>
    public string ReportType { get; set; }

    public void GenerateReport()
    {
        if (ReportType == "CRS")
        {
             // Report generation with employee data in Crystal Report.
             Console.WriteLine("CRS");
        }
        if (ReportType == "PDF")
        {
            // Report generation with employee data in PDF.
            Console.WriteLine("PDF");
        }
     }
}