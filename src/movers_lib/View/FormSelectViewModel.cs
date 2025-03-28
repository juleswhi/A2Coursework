using MaterialSkin.Controls;
using Model;
using static View.FormSelectViewModel.SelectType;

namespace View;

public partial class FormSelectViewModel : Form, GenericCreateableForm {
    protected Type? _currentType;

    public FormSelectViewModel() {
        InitializeComponent();

        var fore = Earth();
        var back = Almond();

        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = back;
        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = fore;
        dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = back;

        dataGridView.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

        dataGridView.RowHeadersDefaultCellStyle.BackColor = back;
        dataGridView.RowHeadersDefaultCellStyle.ForeColor = fore;
        dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = Earth();

        dataGridView.RowsDefaultCellStyle.BackColor = back;
        dataGridView.RowsDefaultCellStyle.ForeColor = fore;
        dataGridView.RowsDefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.RowsDefaultCellStyle.SelectionForeColor = Earth();

        dataGridView.AdvancedRowHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedRowHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedRowHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedRowHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

        dataGridView.GridColor = Color.LightGray;
        dataGridView.DefaultCellStyle.BackColor = back;
        dataGridView.DefaultCellStyle.ForeColor = fore;
        dataGridView.DefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.DefaultCellStyle.SelectionForeColor = Earth();

        // TODO: Fix state keeping after selecting foreign key.

        dataGridView.BackgroundColor = back;
        dataGridView.ForeColor = fore;
    }

    public enum SelectType {
        GetKey,
    }

    public void SetCallback(Action<Type, DataGridView> callback) {
        var btn = Controls.OfType<MaterialButton>().FirstOrDefault();

        if (btn is null) return;

        btn.Click += (s, e) => {
            callback(_currentType!, dataGridView);
        };
    }

    public void SetCallbackReturnKey(Action<int> callback) {
        var select_btn = Controls.OfType<MaterialButton>().FirstOrDefault();
        if (select_btn is null) return;

        select_btn.Click += (s, e) => {
            if (dataGridView.SelectedRows.Count != 1) return;

            dynamic db_query_result = (typeof(DAL).
                GetMethod(nameof(DAL.Query))!.
                MakeGenericMethod(_currentType!).
                Invoke(null, [])!);

            IDatabaseModel typed_model_idx = db_query_result[dataGridView.SelectedRows[0].Index];
            callback(db_query_result[dataGridView.SelectedRows[0].Index].Id);
        };
    }

    public void SetCallbackFromSelectType<T>(SelectType select_type, T database_model) where T : IDatabaseModel {
        var select_btn = Controls.OfType<MaterialButton>().FirstOrDefault();
        if (select_btn is null) return;

        select_btn.Click += select_type switch {
            GetKey => (s, e) => {
                if (dataGridView.SelectedRows.Count == 1) {
                    dynamic db_query_result = (typeof(DAL).
                        GetMethod(nameof(DAL.Query))!.
                        MakeGenericMethod(_currentType!).
                        Invoke(null, [])!);

                    IDatabaseModel typed_model_idx = db_query_result[dataGridView.SelectedRows[0].Index];

                    var get_primary_key = (IEnumerable<(string, int)>)typeof(ModelHelper).
                        GetMethod(nameof(ModelHelper.GetPrimaryKey))!.
                        MakeGenericMethod(_currentType!).
                        Invoke(null, [typed_model_idx])!;

                    var primary_key = get_primary_key.First().Item2;

                    if (FormCreate.PreviousFormType is not null) {
                        ShowGCFR(typeof(FormCreate), FormCreate.PreviousFormType);
                    } else ShowGCF<FormCreate, T>();

                    if (database_model is Clean clean) {
                        // Log data about clean
                        LOG($"Clean: {clean}, Clean.CustomerId: {clean.CustomerId}, Clean.BookDate: {clean.BookDate}, Clean.StartDate: {clean.StartDate}, Clean.EndDate: {clean.EndDate}, Clean.Price: {clean.Price}");
                    }

                    // ((Master as FormSkeleton)!.CurrentForm as FormCreate)!.AssignForeignKey!.Invoke(primary_key);

                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().
                        GetMethod(nameof(form.Populate))!.
                        MakeGenericMethod(typeof(T)!);
                    form_meth.Invoke(form, [database_model]);

                    var prop_val = ((Master as FormSkeleton)!.CurrentForm as FormCreate)!.PropertyValues.First(x => x.Type == _currentType);
                    (prop_val.Control as MaterialButton)!.Text = primary_key.ToString();
                    prop_val.Validated = true;
                    ((Master as FormSkeleton)!.CurrentForm as FormCreate)!.OnValidationChange.Invoke();
                }
            }
            ,
            _ => (s, e) => { }
        };
    }

    public void Create<T>() where T : IDatabaseModel {
        var values = DAL.Query<T>();
        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        _currentType = typeof(T);

        var b = new MaterialButton() { Text = "Select" };

        b.UseAccentColor = true;
        b.Enabled = false;

        Controls.Add(b);

        var horizontalSpace = dataGridView.Width;

        int totalButtonsWidth = 0;
        foreach (var button in Controls.OfType<MaterialButton>()) {
            totalButtonsWidth += button.Width;
        }

        // Calculate the available space between buttons
        int availableSpace = horizontalSpace - totalButtonsWidth;
        int spacing = availableSpace / (2);

        int startX = (this.ClientSize.Width - horizontalSpace) / 2;
        int currentX = startX + spacing;

        foreach (var button in Controls.OfType<MaterialButton>()) {
            button.Location = new Point(currentX, dataGridView.Bottom + 30);
            currentX += button.Width + spacing;
        }

        dataGridView.RowStateChanged += (s, e) => {
            foreach (var btn in Controls.OfType<MaterialButton>()) {
                btn.Enabled = dataGridView.SelectedRows.Count == 1;
            }
        };
    }
}
