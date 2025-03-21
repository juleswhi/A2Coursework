using QuestPDF.Fluent;

namespace Reports;

public static class PdfTools {
    public static MemoryStream LoadPdf(byte[] pdf) =>
        new MemoryStream(pdf);

    public static byte[] GeneratePdf(IReportModel model)
        => new ReportDocument(model).GeneratePdf();

    public static MemoryStream LoadGeneratePdf(IReportModel model) => LoadPdf(GeneratePdf(model));
}
