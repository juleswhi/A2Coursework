using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Reports;

public class ReportDocument : IDocument {
    public IReportModel Model { get; }
    public ReportDocument(IReportModel model) {
        Model = model;
    }

    public void Compose(IDocumentContainer container) {
        container.
            Page(page => {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(Model.ComposeBody);

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
                    .Text(Model.Title()).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
            });

            row.ConstantItem(100).Height(50).Placeholder();
        });
    }

    private void ComposeContent(IContainer container) =>
        container.
            PaddingVertical(40).
            Height(250).
            Background(Colors.Grey.Lighten3).
            AlignCenter().
            AlignMiddle().
            Text("Content").FontSize(16);
}
