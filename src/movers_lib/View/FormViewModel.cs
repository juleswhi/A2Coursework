using Database;
using MaterialSkin.Controls;
using Forms;
using Model;
using System.Reflection;

namespace View;

public partial class FormViewModel : Form, GenericCreateableForm
{
    private Type? _currentType;
    private bool isRowSelected => dataGridView.SelectedRows.Count == 1;
    private Point btnCreateCenter = new();
    private Action<int>? deleteAction;
    private Func<object?>? selectedAction;
    private bool editMode = false;
    public FormViewModel()
    {
        InitializeComponent();
        btnCreate.UseAccentColor = true;
        btnDelete.UseAccentColor = true;
        dataGridView.RowStateChanged += (s, e) =>
        {
            btnDelete.Enabled = dataGridView.SelectedRows.Count == 1;
            editMode = btnDelete.Enabled;
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
            DAL.Delete<T>($"Id = {values[i].FormatPrimaryKey()}");

        selectedAction = () =>
            Query<T>()[dataGridView.SelectedRows[0].Index];
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        ShowForm<FormLogin>();
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        var rows = dataGridView.SelectedRows;
        var edit = false;
        object? val = null;
        if (rows.Count == 1)
        {
            edit = true;
            val = selectedAction!();
        }


        // Can't invoke generic with Type so use reflection
        var method = typeof(FormManager)!.GetMethod(nameof(ShowGCF));
        var generic = method!.MakeGenericMethod(typeof(FormCreate), _currentType!);
        generic.Invoke(null, null);

        if (!edit) return;

        var form = Master!.CurrentlyDisplayedForm as FormCreate;
        var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(_currentType!);

        form_meth.Invoke(form, [val]);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        var rows = dataGridView.SelectedRows;
        if (rows.Count != 1) return;
        var row = rows[0];

        deleteAction?.Invoke(row.Index);
    }
}