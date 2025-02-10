using MaterialSkin.Controls;
using Forms;
using Model;

namespace View;

public partial class FormSkeleton : Form, IFormMaster
{
    public Form current_form => panelHolder.Controls.OfType<Form>().ToList().FirstOrDefault()!;
    public Form CurrentlyDisplayedForm { get => current_form; }

    public FormSkeleton()
    {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        BackColor = Almond();

        btnHome.Click += (s, e) => ShowForm<FormHome>();
        btnJobs.Click += (s, e) => ShowGCF<FormViewModel, Clean>();
        btnStock.Click += (s, e) => ShowGCF<FormViewModel, Product>();
        btnStaff.Click += (s, e) => ShowGCF<FormViewModel, Employee>();
        btnSettings.Click += (s, e) => ShowForm<FormSettings>();
    }
    public Panel GetHolder() => panelHolder;

    public void LoadForm(Form form)
    {
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Enabled = true;
        form.Visible = true;

        panelHolder.Controls.Clear();
        panelHolder.Controls.Add(form);
        panelHolder.Show();
        form.Show();

        Refresh();
    }
}
