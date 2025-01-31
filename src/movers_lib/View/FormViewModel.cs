using database;
using MaterialSkin.Controls;
using movers_lib.forms;
using movers_lib.model;
using System.Reflection;

namespace movers_lib.View;

public partial class FormViewModel : Form, GenericCreateableForm
{
    private Type? _currentType;
    private bool isRowSelected => dataGridView.SelectedRows.Count == 1;
    private Point btnCreateCenter = new();
    private Action<int>? deleteAction;
    public FormViewModel()
    {
        InitializeComponent();
        btnBack.UseAccentColor = true;
        btnCreate.UseAccentColor = true;
        btnDelete.UseAccentColor = true;
        dataGridView.RowStateChanged += (s, e) =>
        {
            btnDelete.Enabled = dataGridView.SelectedRows.Count == 1;
            if(_currentType is not null)
            {
                btnCreate.Text = $"{(isRowSelected ? "Edit" : "Create")} {_currentType.Name}";
                btnCreate.Location = btnCreateCenter;
                btnCreate.Location = new(btnCreate.Location.X, btnCreate.Location.Y);
            }
        };
    }

    public void Create<T>() where T : DatabaseModel
    {
        var values = DAL.Query<T>([]);
        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        btnCreate.Width = size.Width;
        btnCreate.Text = $"{(isRowSelected ? "Edit" : "Create")} {typeof(T).Name}";
        btnCreateCenter = new(btnCreate.Location.X - (int)(0.5 * btnCreate.Width), btnCreate.Location.Y);
        _currentType = typeof(T);

        deleteAction = (i) =>
        {
            var val = values[i];
            LOG($"{val.FormatPrimaryKey()}");
            val.Delete($"Id = {val.FormatPrimaryKey()}");
        };
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        ShowForm<FormLogin>();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        // Can't invoke generic with Type so use reflection
        var method = typeof(FormManager)!.GetMethod(nameof(ShowGCF));
        var generic = method!.MakeGenericMethod(typeof(FormCreate), _currentType!);
        generic.Invoke(null, null);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var rows = dataGridView.SelectedRows;
        if (rows.Count != 1) return;
        var row = rows[0];

        deleteAction?.Invoke(row.Index);
    }
}