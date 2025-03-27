using Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reports;

public class ReportDeliveriesModel : QuestPDF.Infrastructure.IDocument {
    public List<StockReorder> Deliveries { get; set; } = DAL.Query<StockReorder>().Where(x => x.Status == "En Route" || x.Status == "Processing").ToList();
    public string Title() => "Deliveries";

    public void Compose(IDocumentContainer container) {
        container.
            Page(page => {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Column(c => {
                    c.Item().Element(ComposeDescription);
                    c.Item().Element(ComposeBody);
                });

                page.Footer().AlignCenter().Text(x => {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
            });
    }

    private void ComposeDescription(IContainer container) {
       container.Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
        {
            column.Spacing(5);
            column.Item().Text("Description").FontSize(14);
            column.Item().Text("All Deliveries that are either En Route ( In Transit ) or being processed.");
        }); 
    }

    private void ComposeHeader(IContainer container) {
        container.Row(row => {
            row.RelativeItem().Column(column => {
                column.Item()
                    .Text(Title()).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            });
        });
    }

    public void ComposeBody(IContainer container) {
        container.Table(table => {
            table.ColumnsDefinition(columns => {
                //columns.ConstantColumn(40);
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            table.Header(header => {
                //header.Cell().Element(CellStyle).Text("Id");
                header.Cell().Element(CellStyle).Text("Stock Name");
                header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                header.Cell().Element(CellStyle).AlignRight().Text("Expected Arrival");
                header.Cell().Element(CellStyle).AlignRight().Text("Status");

                static IContainer CellStyle(IContainer container) {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            foreach (var item in Deliveries) {
                var stock = DAL.Query<Stock>().First(x => x.Id == item.StockId);
                //table.Cell().Element(CellStyle).Text(item.Id.ToString());
                table.Cell().Element(CellStyle).Text($"{stock.Name}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Quantity}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.ExpectedDate}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Status}");

                static IContainer CellStyle(IContainer container) {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
