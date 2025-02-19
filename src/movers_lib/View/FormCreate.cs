using MaterialSkin.Controls;
using Model;
using Nevron.Nov.WinFormControls;
using System.Reflection;

namespace View;

public partial class FormCreate : Form, GenericCreateableForm {
    private Type? _currentType;
    private List<MaterialTextBox> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().ToList();
    private int? foreign_id = null;

    private static Dictionary<Type, PropertyInfo[]> _propCache = new();

    public Action<int>? AssignForeignKey;

    public FormCreate() {
        InitializeComponent();
    }

    private List<Type> _skips = [typeof(PrimaryKey), typeof(InitialValueInt), typeof(InitialValueString)];

    public void Create<T>() where T : IDatabaseModel {
        _currentType = typeof(T);

        // Store properties in cache if needed later
        PropertyInfo[] props;
        if (_propCache.ContainsKey(_currentType)) {
            props = _propCache[_currentType];
        } else {
            props = _currentType.GetProperties();
            _propCache[_currentType] = props;
        }

        var valid_props = props.Where(x => !x.CustomAttributes.Any(x => _skips.Contains(x.AttributeType)));

        foreach (var prop in props) {


            panel1.Controls.Add(new MaterialLabel() { Text = prop.Name });
            var txtBox = new MaterialTextBox();

            if (Attribute.GetCustomAttribute(prop, typeof(PrimaryKey)) != null ||
                Attribute.GetCustomAttribute(prop, typeof(InitialValueInt)) != null ||
                Attribute.GetCustomAttribute(prop, typeof(InitialValueString)) != null) {
                continue;
            }
            if (Attribute.GetCustomAttribute(prop, typeof(ForeignKey)) != null)
                txtBox.Tag = "foreign";
            if (Attribute.GetCustomAttribute(prop, typeof(Date)) != null)
                txtBox.Tag = "date";

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
        var btns = obj.CreateButtons();

        foreach (var btn in btns) {
            var b = new MaterialButton() { Text = btn.Key, UseAccentColor = true };

            b.Click += (s, e) => {
                btn.Value.Item1.Invoke(
                    textBoxes.Select(x => x.Text).Prepend(foreign_id.ToString()).ToList()!
                    );
            };

            Controls.Add(b);
        }

        var buttons = panel1.Controls.OfType<MaterialButton>().ToList();

        int totalButtonsWidth = 0;
        foreach (var button in buttons) {
            totalButtonsWidth += button.Width;
        }

        int availableSpace = horizontalSpace / totalButtonsWidth;
        int spacing = availableSpace / (btns.Count + 1);

        startX = (this.ClientSize.Width - horizontalSpace) / 2;
        int currentX = startX + spacing;

        foreach (var button in buttons) {
            button.Location = new Point(currentX, panel1.Bottom + 30);
            currentX += button.Width + spacing;
        }

        List<int> to_remove = [];
        List<(Control, Size, Point)> updates = [];
        var idx = panel1.Controls.IndexOf(textBoxes.Where(x => (string)x.Tag! == "foreign").FirstOrDefault());
        if (idx != -1) {
            var s = panel1.Controls[idx].Size;
            var l = panel1.Controls[idx].Location;

            var btn = new MaterialButton {
                Text = "Choose",
                AutoSize = false,
                Type = MaterialButton.MaterialButtonType.Outlined,
                Size = s,
                Location = l
            };

            btn.Click += (s, e) => {
                ShowGCF<FormSelectViewModel, T>();
            };

            AssignForeignKey += x => {
                btn.Text = $"{x}";
            };

            panel1.Controls.RemoveAt(idx);
            panel1.Controls.Add(btn);
        }

        var datetime_idx = 0;
        foreach (var datetime in textBoxes.Where(x => (string)x.Tag! == "date")) {
            idx = panel1.Controls.IndexOf(datetime);
            if (idx != -1) {
                var s = panel1.Controls[idx].Size;
                var l = panel1.Controls[idx].Location;

                var dt = new NDateTimeBoxControl { AutoSize = false, Size = s, Location = l };
                datetime_idx++;

                panel1.Controls.RemoveAt(idx);
                panel1.Controls.Add(dt);
            }
        }
    }

    public void Populate<T>(T obj) {
        obj!.GetType().GetProperties().Zip(_textBoxes).ToList().ForEach(x => {
            x.Second.Text = Convert.ChangeType(x.First.GetValue(obj), x.First.PropertyType)!.ToString();
        });
    }
}
