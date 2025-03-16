using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        [HttpGet("generate-pdf")]
        public IActionResult GeneratePdf()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            //Configs
            int sizeHeaderPage = 20;
            int sizeHeader = 12;
            int sizeContent = 11;
            int paddingLeft = 3;
            int borderSize = 1;

            var pdfDocument = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4.Landscape());
                    page.Margin(sizeHeaderPage);
                    page.Header()
                        .PaddingBottom(20)
                        .Text("Danh mục chi tiết")
                        .Bold()
                        .FontSize(15)
                        .AlignCenter();

                    page.Content().Column(col =>
                    {
                        //    col.Item().Text("Hello, this is a dynamically generated PDF.");
                        //    col.Item().Image(Placeholders.Image(200, 100));

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(50);  // STT
                                columns.RelativeColumn(100); // Mã Thùng
                                columns.RelativeColumn(100); // Thời gian phát sinh (merged column)
                                columns.RelativeColumn(100); // Chi tiết thùng (merged column)

                                columns.RelativeColumn(100); // Mã Thùng
                                columns.RelativeColumn(100); // Thời gian phát sinh (merged column)
                                columns.RelativeColumn(100); // Chi tiết thùng (merged column)
                            });

                            table.Header(header =>
                            {

                                header.Cell().RowSpan(2).Border(borderSize).Text("STT").Bold().FontSize(sizeHeader).AlignCenter();
                                header.Cell().RowSpan(2).Border(borderSize).Text("Mã Thùng").Bold().FontSize(sizeHeader).AlignCenter();
                                header.Cell().ColumnSpan(2).Border(borderSize).Text("Thời gian phát sinh").Bold().AlignCenter().FontSize(sizeHeader).AlignCenter();
                                header.Cell().ColumnSpan(3).Border(borderSize).Text("Chi tiết thùng").Bold().AlignCenter().FontSize(sizeHeader).AlignCenter();

                                header.Cell().Border(borderSize).Text("Ngày bắt đầu").Bold().FontSize(sizeHeader).AlignCenter();
                                header.Cell().Border(borderSize).Text("Ngày kết thúc").Bold().FontSize(sizeHeader).AlignCenter();

                                header.Cell().Border(borderSize).Text("Loại").Bold().FontSize(sizeHeader).AlignCenter();
                                header.Cell().Border(borderSize).Text("Đơn vị").Bold().FontSize(sizeHeader).AlignCenter();
                                header.Cell().Border(borderSize).Text("Số lượng").Bold().FontSize(sizeHeader).AlignCenter();
                            });

                            for (int i = 1; i <= 5; i++)
                            {
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text(i.ToString()).FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text($"Thung-{i}").FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text("01/01/2024").FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text("10/01/2024").FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text("Loại A").FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text("Cái").FontSize(sizeContent);
                                table.Cell().Border(borderSize).PaddingLeft(paddingLeft).Text("100").FontSize(sizeContent);
                            }
                        });
                    });
                //page.Footer().AlignCenter().Text("");
            });
            });

            using var memoryStream = new MemoryStream();
            pdfDocument.GeneratePdf(memoryStream);
            memoryStream.Position = 0;

            return File(memoryStream.ToArray(), "application/pdf", "document.pdf");
        }
    }
}
