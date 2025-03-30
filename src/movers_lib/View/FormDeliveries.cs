using Model;

namespace View;

public partial class FormDeliveries : Form {
    public FormDeliveries() {
        InitializeComponent();
        BackColor = Color.White;

        labelPendingDelivieriesValue.Text = DAL.Query<StockReorder>().
            Where(x => x.Status == "Processing").
            Count().
            ToString();

        labelDeliveredValue.Text = DAL.Query<StockReorder>().
            Where(x => x.Status == "Delivered").
            Count().
            ToString();

        labelLateValue.Text = DAL.Query<StockReorder>().
            Where(x => Convert.ToDateTime(x.ExpectedDate) < DateTime.Now).
            Count().
            ToString();

        cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis {
            Title = "Months",
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
        });

        cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis {
            Title = "Deliveries Received",
            LabelFormatter = value => value.ToString(),
            Separator = new LiveCharts.Wpf.Separator()
        });

        var series_x = new LiveCharts.Wpf.LineSeries {
            Title = "Revenue",
            Values = new LiveCharts.ChartValues<double> { 2, 4, 3, 2, 5, 2, 3, 4, 1, 3, 6, 7 }
        };

        cartesianChart1.Series = [series_x];

        btnProcessingDeliveries.Click += (s, e) => ShowGCFView<FormViewModel, StockReorder>(DAL.Query<StockReorder>().Where(x => x.Status == "Processing").ToList());
        btnDeliveredDeliveries.Click += (s, e) => ShowGCFView<FormViewModel, StockReorder>(DAL.Query<StockReorder>().Where(x => x.Status == "Delivered").ToList());
        btnLateDeliveries.Click += (s, e) => ShowGCFView<FormViewModel, StockReorder>(DAL.Query<StockReorder>().Where(x => Convert.ToDateTime(x.ExpectedDate) < DateTime.Now && x.Status != "Delivered").ToList());
    }
}
