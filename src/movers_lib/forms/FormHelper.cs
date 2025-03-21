using Reports;
using View;
using static Reports.PdfTools;

namespace Forms;

public static class FormHelper {
    public static void CenterX(this Control control, int x) {
        control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)) + x, control.Location.Y);
    }

    public static void CenterY(this Control control, int y) {
        control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height) - y);
    }

    public static void PassPdfToViewer(QuestPDF.Infrastructure.IDocument model) {
        ((Master as FormSkeleton)!.CurrentForm as FormReportViewer)?.PassPdf(LoadGeneratePdf(model));
    }

    public static Color Earth() => Color.FromArgb(255, 149, 113, 79);
    public static Color Sand() => Color.FromArgb(255, 199, 175, 148);
    public static Color Almond() => Color.FromArgb(255, 234, 222, 208);
    public static Color Moss() => Color.FromArgb(255, 140, 145, 108);
    public static Color Sage() => Color.FromArgb(255, 172, 176, 135);
}