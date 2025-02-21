using MaterialSkin.Controls;
using Model;
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

        dataGridView.BackgroundColor = back;
        dataGridView.ForeColor = fore;
    }

    public void Create<T>() where T : IDatabaseModel {
        var values = DAL.Query<T>([]);
        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        _currentType = typeof(T);



        var b = new MaterialButton() { Text = "Select" };

        b.Click += (s, e) => {
            if (dataGridView.SelectedRows.Count == 1) {
                var val = (T)Query<T>()[dataGridView.SelectedRows[0].Index];

                var primary = val.GetPrimaryKey().First().Item2;

                if (FormCreate.PreviousFormType is not null) {
                    ShowGCFR(typeof(FormCreate), FormCreate.PreviousFormType);
                } else ShowGCF<FormCreate, T>();

                ((Master as FormSkeleton)!.CurrentForm as FormCreate)!.AssignForeignKey!.Invoke(primary);
            }
        };

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
