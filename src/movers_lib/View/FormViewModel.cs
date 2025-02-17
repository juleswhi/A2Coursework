using Forms;
using MaterialSkin.Controls;
using Model;

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
        btnCreate.Enabled = false;
        btnDelete.Enabled = false;
        btnCreate.Visible = false;
        btnDelete.Visible = false;
        dataGridView.RowStateChanged += (s, e) =>
        {
            btnDelete.Enabled = dataGridView.SelectedRows.Count == 1;
            editMode = btnDelete.Enabled;
            if (_currentType is not null)
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
        _currentType = typeof(T);

        deleteAction = (i) => { };
        // DAL.Delete<T>($"Id = {values[i].FormatPrimaryKey()}");

        selectedAction = () =>
            Query<T>()[dataGridView.SelectedRows[0].Index];

        var obj = (DatabaseModel)Activator.CreateInstance(typeof(T))!;
        var buttons = obj.Buttons();

        int x = 0;

        foreach (var btn in buttons)
        {
            var b = new MaterialButton()
            {
                Text = btn.Key,
            };

            b.Click += (s, e) =>
            {
                if (dataGridView.SelectedRows.Count != 1) return;
                var data = Query<T>()[dataGridView.SelectedRows[0].Index];
                btn.Value.Invoke((DatabaseModel)data);
            };

            b.UseAccentColor = true;

            b.Location = btnCreate.Location;
            b.Location = new Point(b.Location.X + x, b.Location.Y);
            x += (int)(b.Size.Width * 1.5);

            Controls.Add(b);
        }
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