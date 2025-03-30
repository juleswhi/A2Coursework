using MaterialSkin.Controls;
using Model;

namespace View;

public partial class FormViewModel : Form, GenericCreateableForm {
    protected Type? _currentType;

    public FormViewModel() {
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

        dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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

    public List<IDatabaseModel>? RecordsShown { get; set; } = null;

    public void Create<T>() where T : IDatabaseModel {
        List<T> values;
        if (RecordsShown is List<IDatabaseModel> records) {
            values = records.Select(x => (T)x).ToList();
        } else {
            values = DAL.Query<T>();
        }

        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        _currentType = typeof(T);

        var obj = (IDatabaseModel)Activator.CreateInstance(typeof(T))!;
        var buttons = obj.ViewButtons();

        foreach (var btn in buttons) {
            var b = new MaterialButton() { Text = btn.Key, UseAccentColor = true };

            b.Click += (s, e) => {
                btn.Value.Item1.Invoke(
                    dataGridView.SelectedRows.Count == 1 ?
                        (IDatabaseModel)(RecordsShown == null ? Query<T>().Select(x => (IDatabaseModel)x).ToList() : RecordsShown)[dataGridView.SelectedRows[0].Index]
                        : null
                    );
            };

            b.UseAccentColor = true;

            Controls.Add(b);
        }

        var horizontalSpace = dataGridView.Width;

        int totalButtonsWidth = 0;
        foreach (var button in Controls.OfType<MaterialButton>()) {
            totalButtonsWidth += button.Width;
        }

        // Calculate the available space between buttons
        int availableSpace = horizontalSpace - totalButtonsWidth;
        int spacing = availableSpace / (buttons.Count + 1);

        int startX = (this.ClientSize.Width - horizontalSpace) / 2;
        int currentX = startX + spacing;

        foreach (var button in Controls.OfType<MaterialButton>()) {
            button.Location = new Point(currentX, dataGridView.Bottom + 30);
            currentX += button.Width + spacing;
        }

        dataGridView.RowStateChanged += (s, e) => {

            if (dataGridView.SelectedCells.Count == 1) {
                //dataGridView.select = dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex];
            }

            foreach (var action in buttons.Zip(Controls.OfType<MaterialButton>())) {
                if (!action.First.Value.Item2) continue;

                action.Second.Enabled = dataGridView.SelectedRows.Count == 1;
            }
        };

        foreach (var action in buttons.Zip(Controls.OfType<MaterialButton>())) {
            if (!action.First.Value.Item2) continue;

            action.Second.Enabled = dataGridView.SelectedRows.Count == 1;
        }
    }
}