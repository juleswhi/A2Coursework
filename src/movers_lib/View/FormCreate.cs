using Forms;
using MaterialSkin.Controls;
using Model;

namespace View;

public partial class FormCreate : Form, GenericCreateableForm {
    private Type? _currentType;
    private List<MaterialTextBox> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().ToList();
    private int? foreign_id = null;

    public FormCreate() {
        InitializeComponent();
    }

    public void Create<T>() where T : IDatabaseModel {
        // Get fields in type
        var props = typeof(T).GetProperties();

        foreach (var prop in props) {
            if (prop.Name == "Id") continue;

            panel1.Controls.Add(new MaterialLabel() { Text = prop.Name });
            var txtBox = new MaterialTextBox();

            if (Attribute.GetCustomAttribute(prop, typeof(PrimaryKey)) != null) {
                txtBox.Text += "Primary";
            }
            if (Attribute.GetCustomAttribute(prop, typeof(ForeignKey)) != null) {
                txtBox.Text += "foreign";
                var foreignKeyButton = new MaterialButton {
                    Text = "Choose",
                    AutoSize = true,
                    Type = MaterialButton.MaterialButtonType.Outlined,
                };
                panel1.Controls.Add(foreignKeyButton);
                txtBox.Tag = "foreign";
            } 
            panel1.Controls.Add(txtBox); 
        }

        var textBoxes = panel1.Controls.OfType<MaterialTextBox>().ToList();
        var textBoxCount = textBoxes.Count();
        var maxLabelSize = props.Select(x => TextRenderer.MeasureText(x.Name, MaterialButton.DefaultFont)).OrderBy(s => s.Width).Reverse().First();
        var maxTextBoxSize = new Size(150, 50);
        var horizontalSpace = panel1.Width;
        var verticalSpace = panel1.Height;

        var labels = panel1.Controls.OfType<MaterialLabel>().ToList();

        int columns = (int)Math.Ceiling(Math.Sqrt(textBoxCount));
        int rows = (int)Math.Ceiling((double)textBoxCount / columns);

        int totalHeightPerRow = maxLabelSize.Height + maxTextBoxSize.Height + 10;

        int availableWidthPerColumn = horizontalSpace / columns;
        int availableHeightPerRow = verticalSpace / rows;

        int textBoxWidth = Math.Min(maxTextBoxSize.Width, availableWidthPerColumn);
        int textBoxHeight = Math.Min(maxTextBoxSize.Height, availableHeightPerRow - maxLabelSize.Height - 10); // Account for label height and spacing
        int labelWidth = Math.Min(maxLabelSize.Width, availableWidthPerColumn);
        int labelHeight = maxLabelSize.Height;

        int horizontalSpacing = (horizontalSpace - (textBoxWidth * columns)) / (columns + 1);
        int verticalSpacing = (verticalSpace - (totalHeightPerRow * rows)) / (rows + 1);

        int startX = 10;
        int startY = 10;

        for (int i = 0; i < textBoxCount; i++) {
            int row = i / columns;
            int col = i % columns;

            int labelX = startX + horizontalSpacing + col * (textBoxWidth + horizontalSpacing);
            int labelY = startY + verticalSpacing + row * (totalHeightPerRow + verticalSpacing);

            int textBoxX = labelX;
            int textBoxY = labelY + labelHeight + 10;

            labels[i].Location = new Point(labelX, labelY);
            labels[i].Size = new Size(labelWidth, labelHeight);

            textBoxes[i].Location = new Point(textBoxX, textBoxY);
            textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
        }

        var obj = (IDatabaseModel)Activator.CreateInstance(typeof(T))!;
        var buttons = obj.CreateButtons();

        foreach (var btn in buttons) {
            var b = new MaterialButton() { Text = btn.Key };

            b.Click += (s, e) => {
                btn.Value.Item1.Invoke(
                    panel1.Controls.OfType<MaterialTextBox>().Select(x => x.Text).Prepend(foreign_id.ToString()).ToList()!
                    );
            };

            b.UseAccentColor = true;
            // b.Type = MaterialButton.MaterialButtonType.Text;

            Controls.Add(b);
        }

        int totalButtonsWidth = 0;
        foreach (var button in Controls.OfType<MaterialButton>()) {
            totalButtonsWidth += button.Width;
        }

        int availableSpace = horizontalSpace / totalButtonsWidth;
        int spacing = availableSpace / (buttons.Count + 1);

        startX = (this.ClientSize.Width - horizontalSpace) / 2;
        int currentX = startX + spacing;

        foreach (var button in Controls.OfType<MaterialButton>()) {
            button.Location = new Point(currentX, panel1.Bottom + 30);
            currentX += button.Width + spacing;
        }

        foreach (var action in buttons.Zip(Controls.OfType<MaterialButton>())) {
            if (!action.First.Value.Item2) continue;
        }

        var idx = panel1.Controls.IndexOf(panel1.Controls.OfType<MaterialTextBox>().Where(x => (string)x.Tag == "foreign").FirstOrDefault());
        if(idx != -1) {
            var s = panel1.Controls[idx].Size;
            var l = panel1.Controls[idx].Location;

            var btn = panel1.Controls.OfType<MaterialButton>().First();

            btn.Size = s;
            btn.AutoSize = false;
            btn.Location = l;

            panel1.Controls.RemoveAt(idx);
        }

        // panel1.Controls.Remove(panel1.Controls.OfType<MaterialTextBox>().Where(x => (string)x.Tag == "foreign").FirstOrDefault());

        _currentType = typeof(T);
    }

    public void Populate<T>(T obj) {
        obj!.GetType().GetProperties().Zip(_textBoxes).ToList().ForEach(x => {
            x.Second.Text = Convert.ChangeType(x.First.GetValue(obj), x.First.PropertyType)!.ToString();
        });
    }

    private void btnBack_Click(object sender, EventArgs e) {
        var method = typeof(FormManager)!.GetMethod(nameof(ShowGCF));
        var generic = method!.MakeGenericMethod(typeof(FormViewModel), _currentType!);
        generic.Invoke(null, null);
    }

    private void btnCreate_Click(object sender, EventArgs e) {
        if (_currentType is null) return;

        var obj = Activator.CreateInstance(_currentType);
        Convert.ChangeType(obj, _currentType);

        var props = _currentType.GetProperties().ToList();
        props.RemoveAt(0);
        var textvalues = _textBoxes.Select(x => x.Text);

        props.Zip(textvalues).
            ToList().
            ForEach(x => x.First.
                SetValue(obj, Convert.
                    ChangeType(x.Second, x.First.PropertyType)));

        var meth = typeof(DAL).GetMethod(nameof(DAL.Create))!;
        var new_meth = meth.MakeGenericMethod(_currentType);
        new_meth.Invoke(null, [obj!]);

        ShowGCFR(typeof(FormViewModel), _currentType);
    }
}
