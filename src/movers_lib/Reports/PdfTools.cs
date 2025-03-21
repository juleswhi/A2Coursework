using QuestPDF.Fluent;

namespace Reports;

public static class PdfTools {
    public static MemoryStream LoadPdf(byte[] pdf) =>
        new MemoryStream(pdf);

    public static byte[] GeneratePdf(QuestPDF.Infrastructure.IDocument model)
        => model.GeneratePdf();

    public static MemoryStream LoadGeneratePdf(QuestPDF.Infrastructure.IDocument model) => LoadPdf(GeneratePdf(model));
}
