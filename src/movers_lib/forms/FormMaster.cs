using movers_lib.model;
using MaterialSkin;

namespace movers_lib.forms;
public partial class FormMaster : Form, IFormMaster
{
    public FormMaster()
    {
        InitializeComponent();
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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
