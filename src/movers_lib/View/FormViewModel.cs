using Forms;
using MaterialSkin.Controls;
using Model;

namespace View;

public partial class FormViewModel : Form, GenericCreateableForm
{
    private Type? _currentType;
    private bool isRowSelected => dataGridView.SelectedRows.Count == 1;
    private Point btnCreateCenter = new();

    public FormViewModel()
    {
        InitializeComponent();

        var fore = Earth();
        var back = Almond();

        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = back;
        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = fore;
        dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = back;

        dataGridView.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        // dataGridView.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dataGridView.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

        dataGridView.RowHeadersDefaultCellStyle.BackColor = back;
        dataGridView.RowHeadersDefaultCellStyle.ForeColor = fore;
        dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = Earth();

        dataGridView.RowsDefaultCellStyle.BackColor = back;
        dataGridView.RowsDefaultCellStyle.ForeColor = fore;
        dataGridView.RowsDefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.RowsDefaultCellStyle.SelectionForeColor = Earth();

        // dataGridView.AdvancedRowHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Single;
        dataGridView.AdvancedRowHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedRowHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
        dataGridView.AdvancedRowHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
        // dataGridView.AdvancedRowHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        dataGridView.AdvancedRowHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

        dataGridView.GridColor = Color.LightGray;
        dataGridView.DefaultCellStyle.BackColor = back;
        dataGridView.DefaultCellStyle.ForeColor = fore;
        dataGridView.DefaultCellStyle.SelectionBackColor = Sand();
        dataGridView.DefaultCellStyle.SelectionForeColor = Earth();

        dataGridView.BackgroundColor = back;
        dataGridView.ForeColor = fore;
    }

    public void Create<T>() where T : DatabaseModel
    {
        var values = DAL.Query<T>([]);
        dataGridView.DataSource = values;
        string name = $"Create {typeof(T).Name}";
        var size = TextRenderer.MeasureText(name, MaterialButton.DefaultFont);
        _currentType = typeof(T);

        var obj = (DatabaseModel)Activator.CreateInstance(typeof(T))!;
        var buttons = obj.Buttons();

        int x = 0;

        foreach (var btn in buttons)
        {
            var b = new MaterialButton() { Text = btn.Key };

            b.Click += (s, e) =>
            {
                btn.Value.Item1.Invoke(
                    dataGridView.SelectedRows.Count == 1 ? 
                        (DatabaseModel)Query<T>()[dataGridView.SelectedRows[0].Index]
                        : null
                    );
            };

            b.UseAccentColor = true;

            b.Location = new Point(20, dataGridView.Bottom + 30);
            b.Location = new Point(b.Location.X + x, b.Location.Y);
            x += (int)(b.Size.Width * 1.5);

            Controls.Add(b);

        }

        var horizontalSpace = dataGridView.Width;

        int totalButtonsWidth = 0;
        foreach (var button in Controls.OfType<MaterialButton>())
        {
            totalButtonsWidth += button.Width;
        }

        // Calculate the available space between buttons
        int availableSpace = horizontalSpace - totalButtonsWidth;
        int spacing = availableSpace / (buttons.Count + 1);

        int startX = (this.ClientSize.Width - horizontalSpace) / 2;
        int currentX = startX + spacing;

        foreach (var button in Controls.OfType<MaterialButton>())
        {
            button.Location = new Point(currentX, dataGridView.Bottom + 30);
            currentX += button.Width + spacing;
        }

        dataGridView.RowStateChanged += (s, e) =>
        {
            foreach(var action in buttons.Zip(Controls.OfType<MaterialButton>()))
            {
                if (!action.First.Value.Item2) continue;

                action.Second.Enabled = dataGridView.SelectedRows.Count == 1;
            }
        };

        foreach (var action in buttons.Zip(Controls.OfType<MaterialButton>()))
        {
            if (!action.First.Value.Item2) continue;

            action.Second.Enabled = dataGridView.SelectedRows.Count == 1;
        }
    }
}