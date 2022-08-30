using MediatR;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Feautures.Invoices.Commands;

namespace ZooWebShopAPI.Feautures.Invoices.Handlers
{
    public class GenerateInvoiceHandler : IRequestHandler<GenerateInvoiceCommand, byte[]>
    {
        public async Task<byte[]> Handle(GenerateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = GeneratePdfInvoice(request.dto);
            return await Task.FromResult(result);
        }

        private byte[] GeneratePdfInvoice(InvoiceDataDto dto)
        {
            var result = Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);

                    page.Header()
                        .AlignLeft()
                        .Row(row =>
                        {
                            row.ConstantItem(150)
                                .Image($"{Directory.GetCurrentDirectory()}/wwwroot/Images/logo.png");

                            row.RelativeItem()
                            .Height(150)
                            .PaddingRight(20)
                            .Column(column =>
                            {
                                column.Item()
                                .AlignLeft()
                                .Text("Invoice")
                                .FontFamily(Fonts.Tahoma)
                                .FontSize(22)
                                .SemiBold();

                                column.Item()
                                .Text("Invoice #4211");

                                column.Item()
                                .Text("Issue date: 25.10.2020");

                                column.Item()
                                .Text("Due date: 08.11.2020");
                            });
                        });

                    page.Content()
                    .Grid(grid =>
                    {
                        grid.VerticalSpacing(15);
                        grid.HorizontalSpacing(15);
                        grid.AlignCenter();
                        grid.Columns(12);

                        grid.Item(6)
                        .Column(column =>
                        {
                            column.Item()
                            .Text("Bill to")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(16)
                            .SemiBold();

                            column.Item()
                            .Text("John Smith")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text("2 Court Square")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text("New York, NY 12210")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);
                        });

                        grid.Item(6)
                        .Column(column =>
                        {
                            column.Item()
                            .Text("Ship to")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(16)
                            .SemiBold();

                            column.Item()
                            .Text("John Smith")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text("3787 Pineview Drive")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text("Cambridge, MA 12210")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);
                        });

                        grid.Item(12)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(50);
                                columns.RelativeColumn(1);
                                columns.ConstantColumn(50);
                                columns.ConstantColumn(50);
                            });

                            table.Header(header =>
                            {
                                header.Cell().AlignCenter().Text("#").SemiBold();
                                header.Cell().Text("Product name").SemiBold();
                                header.Cell().AlignCenter().Text("Quantity").SemiBold();
                                header.Cell().AlignCenter().Text("Price").SemiBold();
                            });

                            foreach (var i in Enumerable.Range(1, 29))
                            {
                                table.Cell().AlignCenter().Text(i);
                                table.Cell().Text("PRODUCT NAME");
                                table.Cell().AlignCenter().Text(i);
                                table.Cell().AlignCenter().Text(i);
                            }

                        });
                        grid.Item(12)
                        .AlignRight()
                        .Table(table =>
                        {

                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(100);
                                columns.ConstantColumn(100);
                                columns.ConstantColumn(100);
                            });
                            table.Header(header =>
                            {
                                header.Cell().AlignRight().Text("Subtotal").SemiBold();
                                header.Cell().AlignRight().Text("Sales Tax 23 %").SemiBold();
                                header.Cell().AlignRight().Text("TOTAL").SemiBold();
                            });

                            table.Cell().AlignRight().Text("!23");
                            table.Cell().AlignRight().Text("!23");
                            table.Cell().AlignRight().Text("!23");

                        });

                    });


                    page.Footer()
                        .Height(1, QuestPDF.Infrastructure.Unit.Inch)
                        .AlignMiddle()
                        .AlignCenter().Text(text =>
                        {
                            text.DefaultTextStyle(x => x.FontSize(16));
                            text.Span("Page number ");
                            text.CurrentPageNumber();
                            text.Span(" out of ");
                            text.TotalPages();
                        });
                });
            }).GeneratePdf();

            return result;
        }
    }
}
