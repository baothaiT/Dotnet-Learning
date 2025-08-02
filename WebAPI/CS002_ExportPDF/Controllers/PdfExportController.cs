using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace CS002_ExportPDF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfExportController : Controller
    {
        [HttpGet("export")]
        public IActionResult ExportPdf()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Create PDF writer
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                pdf.SetDefaultPageSize(PageSize.A4.Rotate());

                Document document = new Document(pdf);

                string fontPath = $"D:/Bao/Tech-Learning/Dotnet/SourceCode/Dotnet-Learning/CheckCode/CS002_ExportPDF/Fonts/Arial.ttf";
                string fontBoldPath = $"D:/Bao/Tech-Learning/Dotnet/SourceCode/Dotnet-Learning/CheckCode/CS002_ExportPDF/Fonts/Arial_Bold.ttf";

                // Check if font file exists
                if (!System.IO.File.Exists(fontPath) || !System.IO.File.Exists(fontBoldPath))
                {
                    Console.WriteLine($"Error: Font file not found");
                    return BadRequest("Font file is missing. Please check the file path.");
                }

                // Load a custom font (Arial, Roboto, etc.)
                PdfFont font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                PdfFont font_bold = PdfFontFactory.CreateFont(fontBoldPath, PdfEncodings.IDENTITY_H);


                //Add Title(Centered)
                Paragraph title = new Paragraph("Danh mục chi tiết")
                    .SetFont(font_bold)
                    .SetFontSize(20)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginBottom(20); // Space before table
                document.Add(title);

                // Header Names
                string[] headers = { "STT", "Loại chứng từ", "Từ ngày", "Testaaaa1", "Testaaaa2", "Testaaaa3", "Testaaaa4", "Testaaaa5" };

                // Determine column widths based on text length
                float fontSize = 12; // Adjust if needed
                float[] columnWidths = headers
                    .Select(header => font.GetWidth(header, fontSize) + 20) // Add padding
                    .ToArray();

                // Create a table with auto-calculated column widths
                Table table = new Table(columnWidths);
                table.SetWidth(UnitValue.CreatePercentValue(100)); // Full width

                // Add bold headers
                foreach (string header in headers)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFont(font_bold)));
                }

                // Add example rows with the same font
                for (int i = 1; i <= 5; i++)
                {
                    table.AddCell(new Cell().Add(new Paragraph(i.ToString()).SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại {i}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"2024-03-{i:D2}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại1 {i}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại2 {i}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại3 {i}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại4 {i}").SetFont(font)));
                    table.AddCell(new Cell().Add(new Paragraph($"Loại5 {i}").SetFont(font)));
                }

                document.Add(table);
                document.Close();

                // Return PDF file
                return File(stream.ToArray(), "application/pdf", "ExportedTable.pdf");
            }
        }
    }
}
