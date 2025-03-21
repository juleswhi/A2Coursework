using PdfiumViewer;

namespace View;
public partial class FormReportViewer : Form {
    public FormReportViewer() {
        InitializeComponent();
    }

    public void PassPdf(MemoryStream doc) =>
        pdfViewer1.Document = PdfDocument.Load(doc);
}
