using Model;

namespace View;

public partial class FormHome : Form {
    public FormHome() {
        InitializeComponent();
        BackColor = Color.White;

        var active_jobs = DAL.Query<Clean>().Where(x => {
            var start = DateTime.Parse(x.StartDate);
            var end = DateTime.Parse(x.EndDate);
            return start < DateTime.Now && end > DateTime.Now;
        }).Count();

        btnActiveJobs.Click += (s, e) => ShowGCF<FormViewModel, Clean>();
        btnWorkingEmployees.Click += (s, e) => ShowGCF<FormViewModel, Employee>();
        btnPendingDeliveries.Click += (s, e) => ShowForm<FormDeliveries>();

        var total_jobs = DAL.Query<Clean>().Count();

        labelJobsCount.Text = active_jobs.ToString();

        //progressJobs.Minimum = 0;
        //progressJobs.Maximum = total_jobs;
        //progressJobs.Value = active_jobs;

        labelPendingDelivieriesValue.Text = DAL.
            Query<StockReorder>().
            Where(x => Convert.ToDateTime(x.ExpectedDate) > DateTime.Now).
            Where(x => x.Status != "Delivered" || x.Status != "Lost").
            Count().
            ToString();

        labelWorkingEmployees.Text = DAL.Query<Employee>().Count().ToString();

        cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis {
            Title = "Months",
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
        });

        cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis {
            Title = "Revenue",
            LabelFormatter = value => value.ToString(),
            Separator = new LiveCharts.Wpf.Separator()
        });

        var series_x = new LiveCharts.Wpf.LineSeries {
            Title = "Revenue",
            Values = new LiveCharts.ChartValues<double> { 30_000, 10_000, 12_300, 7_010, 54_000, 22_050, 65_000, 10_010, 4_430, 10_300, 12_000, 40_320 }
        };

        cartesianChart1.Series = [series_x];
    }
}
