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

        labelEnRouteValue.Text = DAL.Query<StockReorder>().
            Where(x => x.Status == "En Route").
            Count().
            ToString();

        labelDeliveredValue.Text = DAL.Query<StockReorder>().
            Where(x => x.Status == "Delivered").
            Count().
            ToString();

        labelLateValue.Text = DAL.Query<StockReorder>().
            Where(x => Convert.ToDateTime(x.ExpectedDate) < DateTime.Now && x.Status != "Lost").
            Count().
            ToString();

        labelLostValue.Text = DAL.Query<StockReorder>().
            Where(x => x.Status == "Lost").
            Count().
            ToString();
    }

    private void materialLabel3_Click(object sender, EventArgs e) {

    }
}
