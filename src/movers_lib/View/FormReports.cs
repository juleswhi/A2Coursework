using Reports;

namespace View;

public partial class FormReports : Form {
    public FormReports() {
        InitializeComponent();
        BackColor = Color.White;

        btnReportOne.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportJobsModel());
        };

        btnReportTwo.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportDeliveriesModel());
        };

        btnReportThree.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportJobsCostModel());
        };

        btnReportFour.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportStockAvailableModel());
        };

        btnReportFive.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportStockAmountModel());
        };

        btnReportSix.Click += (s, e) => {
            ShowForm<FormReportViewer>();
            PassPdfToViewer(new ReportJobsFullModel());
        };
    }
}
