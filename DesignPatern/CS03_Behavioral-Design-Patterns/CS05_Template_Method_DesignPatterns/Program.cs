

using CS05_Template_Method_DesignPatterns.Services;
using CS05_Template_Method_DesignPatterns.Services.AbstractClass;

namespace CS05_Template_Method_DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, CS05_Template_Method_DesignPatterns!");
            

            // Create a PDF report
            ReportGenerator pdfReport = new PdfReportGenerator();
            Console.WriteLine("Generating PDF Report:");
            pdfReport.GenerateReport();

            Console.WriteLine();

            // Create an Excel report
            ReportGenerator excelReport = new ExcelReportGenerator();
            Console.WriteLine("Generating Excel Report:");
            excelReport.GenerateReport();
        }
    }
}