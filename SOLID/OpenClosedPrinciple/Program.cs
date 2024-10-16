namespace OpenClosedPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("test OpenClosedPrinciple");
    }
}

#region 

public class ReportGeneration
{
    /// <summary>
    /// Report type
    /// </summary>
    public string ReportType { get; set; }

    /// <summary>
    /// Method to generate report
    /// </summary>
    /// <param name="em"></param>
    public void GenerateReport()
    {
        if (ReportType == "CRS")
        {
             // Report generation with employee data in Crystal Report.
        }
        if (ReportType == "PDF")
        {
            // Report generation with employee data in PDF.
        }
     }
}

#endregion 