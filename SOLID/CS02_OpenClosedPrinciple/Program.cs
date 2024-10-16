using OpenClosedPrinciple.Services.Case;
using OpenClosedPrinciple.Services.Solution;

namespace OpenClosedPrinciple;

public class Program
{
    public static void Main(string[] args)
    {
        #region Case OpenClosedPrinciple
        Console.WriteLine("Case OpenClosedPrinciple");
        ReportGeneration_Case reportGeneration_Case = new ReportGeneration_Case();
        reportGeneration_Case.ReportType = "CRS";
        reportGeneration_Case.GenerateReport();
        #endregion
        
        #region Solution for this case
        IReportGeneration reportGeneration_PDF = new PDFReport();
        reportGeneration_PDF.GenerateReport();

        IReportGeneration reportGeneration_CRS = new CRSReport();
        reportGeneration_CRS.GenerateReport();

        #endregion
        
        
    }
}

