using MaterialSkin.Controls;
using Model;
using System.Reflection;

namespace View;

public partial class FormCreate : Form, GenericCreateableForm {
    public static Type? PreviousFormType { get; private set; } = null;
    public Action<int>? AssignForeignKey;
    public Func<IEnumerable<(string, object)>>? func = null;


    private Type? _currentType;
    private List<MaterialTextBox> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().ToList();

    private int? foreign_id = null;
    private Type? foreign_type = null;

    private static Dictionary<Type, PropertyInfo[]> _propCache = new();


    public FormCreate() {
        InitializeComponent();
    }

    private List<Type> _skips = [typeof(PrimaryKey), typeof(InitialValueInt), typeof(InitialValueString), typeof(InitialValueDate)];

    public void Create<T>() where T : IDatabaseModel {
        _currentType = typeof(T);
        PreviousFormType = _currentType;

        List<(string, Func<string>)> property_values = [];

        // Store properties in cache if needed later
        PropertyInfo[] props;
        if (_propCache.ContainsKey(_currentType)) {
            props = _propCache[_currentType];
        } else {
            props = _currentType.GetProperties();
            _propCache[_currentType] = props;
        }

        var valid_props = props.Where(x => !x.CustomAttributes.Any(x => _skips.Contains(x.AttributeType)));

        foreach (var prop in valid_props) {
            var label = new MaterialLabel() { Text = prop.Name };
            panel1.Controls.Add(label);
            var txtBox = new MaterialTextBox();

            if (Attribute.GetCustomAttribute(prop, typeof(PrimaryKey)) != null ||
                Attribute.GetCustomAttribute(prop, typeof(InitialValueInt)) != null ||
                Attribute.GetCustomAttribute(prop, typeof(InitialValueString)) != null) {
                continue;
            }
            if (Attribute.GetCustomAttribute(prop, typeof(ForeignKey)) != null) {
                var n = prop.Name.Split("Id")[0];
                var type = ModelHelper.ModelTypes.First(x => x.Name == n);
                foreign_type = type;
                txtBox.Tag = "foreign";
            }
            if (Attribute.GetCustomAttribute(prop, typeof(Date)) != null)
                txtBox.Tag = "date";

            panel1.Controls.Add(txtBox);
            property_values.Add((label.Text, () => txtBox.Text));
        }

        var textBoxes = panel1.Controls.OfType<MaterialTextBox>().ToList();

        var textBoxCount = textBoxes.Count();
        var maxLabelSize = props.
            Select(x => TextRenderer.MeasureText(x.Name, MaterialButton.DefaultFont)).
            OrderBy(s => s.Width).
            Reverse().
            First();
        var maxTextBoxSize = new Size(150, 50);
        var horizontalSpace = panel1.Width;
        var verticalSpace = panel1.Height;

        var labels = panel1.Controls.OfType<MaterialLabel>().ToList();

        #region Random Sizing Stuff

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

        #endregion 

        var obj = (IDatabaseModel)Activator.CreateInstance(typeof(T))!;
        var btns = obj.CreateButtons();

        foreach (var btn in btns) {
            var b = new MaterialButton() { Text = btn.Key, UseAccentColor = true };

            b.Click += (s, e) => btn.Value.Item1.Invoke(property_values);

            Controls.Add(b);
        }

        var buttons = Controls.OfType<MaterialButton>().ToList();

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
                ShowGCFR(typeof(FormSelectViewModel), foreign_type!);
            };

            AssignForeignKey += x => {
                btn.Text = $"{x}";
            };

            panel1.Controls.RemoveAt(idx);
            panel1.Controls.Add(btn);

            var prop_val = property_values.ElementAt(idx - 1);
            prop_val.Item2 = () => btn.Text;
            property_values[idx - 1] = prop_val;
        }

        var datetime_idx = 0;
        foreach (var datetime in textBoxes.Where(x => (string)x.Tag! == "date")) {
            idx = panel1.Controls.IndexOf(datetime);
            if (idx != -1) {
                var s = panel1.Controls[idx].Size;
                var l = panel1.Controls[idx].Location;

                var dt = new DateTimePicker { AutoSize = false, Size = s, Location = l };
                datetime_idx++;

                panel1.Controls.RemoveAt(idx);
                panel1.Controls.Add(dt);
                var prop_val = property_values.ElementAt(idx - 1);
                prop_val.Item2 = () => dt.Value.ToString();
                property_values[idx - 1] = prop_val;
            }
        }
    }

    public void Populate<T>(T obj) {
        obj!.GetType().GetProperties().Zip(_textBoxes).ToList().ForEach(x => {
            x.Second.Text = Convert.ChangeType(x.First.GetValue(obj), x.First.PropertyType)!.ToString();
        });
    }
}
