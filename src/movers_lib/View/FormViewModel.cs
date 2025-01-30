using database;
using MaterialSkin.Controls;
using movers_lib.model;

namespace movers_lib.View;

public partial class FormViewModel : Form, GenericCreateableForm
{
    public FormViewModel()
    {
        InitializeComponent();
    }

    public void Create<T>() where T : DatabaseModel
    {
        var values = DAL.Query<T>([]);
        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        btnCreate.Width = size.Width;
        btnCreate.Text = name;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        Trigger<FormLogin>();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        Trigger<FormCreate>();
    }
}