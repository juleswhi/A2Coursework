using Model;

namespace View;

public partial class FormHome : Form
{
    public FormHome()
    {
        InitializeComponent();
        BackColor = Color.White;
        
        var active_jobs = DAL.Query<Clean>().Where(x => {
            var start = DateTime.Parse(x.StartDate);
            var end = DateTime.Parse(x.EndDate);
            return start < DateTime.Now && end > DateTime.Now;
        }).Count();

        var total_jobs = DAL.Query<Clean>().Count();

        labelJobsCount.Text = active_jobs.ToString();
        progressJobs.Minimum = 0;
        progressJobs.Maximum = total_jobs;
        progressJobs.Value = active_jobs;
    }
}
