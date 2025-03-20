using QuestPDF;
using PdfiumViewer;
using QuestPDF.Infrastructure;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace Model.Helpers;
public static class PdfTools {
    public static MemoryStream LoadPdf(byte[] pdf) =>
        new MemoryStream(pdf);

    public static byte[] GeneratePdf(ReportModel model)
        => new ReportDocument(model).GeneratePdf();

    public static MemoryStream LoadGeneratePdf(ReportModel model) => LoadPdf(GeneratePdf(model));
}

public class ReportModel {
    public string Data { get; set; } = String.Empty;
}

public class ReportDocument : IDocument {
    public ReportModel Model { get; }
    public ReportDocument(ReportModel model) {
        Model = model;
    }

    public void Compose(IDocumentContainer container) {
        container.
            Page(page => {
                page.Margin(50);

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);

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
                    .Text(Model.Data).FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
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

