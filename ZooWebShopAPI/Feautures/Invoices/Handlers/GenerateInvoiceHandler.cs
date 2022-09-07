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
            decimal subtotal = 0;

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
                                .Text($"Issue date: {(DateTime.Today).ToString("dd/MM/yyyy")}");

                                column.Item()
                                .Text($"Due date: {(DateTime.Today.Date.AddDays(14)).ToString("dd/MM/yyyy")}");
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
                            .Text($"{dto.User.FirstName} {dto.User.LastName}")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text($"{dto.User.Street}")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text($"{dto.User.City} {dto.User.PostalCode}")
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
                            .Text($"{dto.User.FirstName} {dto.User.LastName}")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text($"{dto.User.Street}")
                            .FontFamily(Fonts.Tahoma)
                            .FontSize(12);

                            column.Item()
                            .Text($"{dto.User.City} {dto.User.PostalCode}")
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
                                header.Cell().AlignCenter().Text("Price").SemiBold();
                                header.Cell().AlignCenter().Text("Quantity").SemiBold();
                            });

                            int iterationCount = 1;

                            foreach(var item in dto.Products)
                            {
                                table.Cell().AlignCenter().Text(iterationCount);
                                table.Cell().Text(item.Product.Name);
                                table.Cell().AlignCenter().Text(Math.Round(item.Product.Price,2));
                                table.Cell().AlignCenter().Text(item.Quantity);
                                iterationCount++;
                                subtotal += (item.Product.Price * item.Quantity);
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

                            table.Cell().AlignRight().Text("$" + Math.Round(subtotal,2));
                            table.Cell().AlignRight().Text("$" + Math.Round(subtotal*0.23m,2));
                            table.Cell().AlignRight().Text("$" + Math.Round(subtotal*1.23m,2));

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
