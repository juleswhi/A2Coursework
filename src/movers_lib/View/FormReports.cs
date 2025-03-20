using static Forms.FormHelper;
namespace View;

public partial class FormReports : Form {
    public FormReports() {
        InitializeComponent();
        BackColor = Color.White;

        btnReportOne.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new() {
                 Data = $"Hello"
            });
        };
    }
}
