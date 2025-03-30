using Model;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reports;

public class ReportStockAmountModel : QuestPDF.Infrastructure.IDocument {
    public List<Stock> Cleans { get; set; } = DAL.
        Query<Stock>().
        Where(x => x.Amount > 0).
        OrderBy(x => x.Amount).
        Reverse().
        ToList();

    public string Title() => "Stock";

    private void ComposeDescription(IContainer container) {
        container.Background(Colors.Grey.Lighten3).Padding(10).Column(column => {
            column.Spacing(5);
            column.Item().Text("Description").FontSize(14);
            column.Item().Text("All current stock available, ordered by amount in descending order");
        });
    }

    public void Compose(IDocumentContainer container) {
        container.
            Page(page => {
                page.Margin(50);

                page.Header().Element(ComposeHeader);

                page.Content().Column(c => {
                    c.Item().Padding(10).Element(ComposeDescription);
                    c.Item().Element(ComposeBody);
                });

                page.Footer().AlignCenter().Text(x => {
                    x.CurrentPageNumber();
                    x.Span(" / ");
                    x.TotalPages();
                });
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
                // columns.ConstantColumn(50);
                columns.RelativeColumn();
                columns.RelativeColumn();
                columns.RelativeColumn();
            });

            table.Header(header => {
                // header.Cell().Element(CellStyle).Text("Id");
                header.Cell().Element(CellStyle).Text("Name");
                header.Cell().Element(CellStyle).AlignRight().Text("Description");
                header.Cell().Element(CellStyle).AlignRight().Text("Amount");

                static IContainer CellStyle(IContainer container) {
                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                }
            });

            foreach (var item in Cleans) {
                // table.Cell().Element(CellStyle).Text(item.Id.ToString());
                table.Cell().Element(CellStyle).Text($"{item.Name}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Description}");
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Amount}");

                static IContainer CellStyle(IContainer container) {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
