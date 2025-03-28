using MaterialSkin.Controls;
using Model;
using System.Reflection;

namespace View;

public partial class FormCreate : Form, GenericCreateableForm {
    public static Type? PreviousFormType { get; private set; } = null;
    public Action<int>? AssignForeignKey;
    public Func<IEnumerable<(string, object)>>? func = null;
    public List<PropValue> PropertyValues = [];

    private Type? _currentType;
    private List<MaterialTextBox> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().ToList();
    private IDatabaseModel? _edited_object;

    private List<bool> Validations = [];
    public Action OnValidationChange = () => { };

    private static Dictionary<Type, PropertyInfo[]> _propCache = new();

    public FormCreate() {
        InitializeComponent();
    }

    private List<Type> _skips = [typeof(PrimaryKey), typeof(InitialValueInt), typeof(InitialValueString), typeof(InitialValueDate)];

    public class PropValue {
        public PropValue(string name, Func<string> value, Control control, Type? type, Action<int>? AssignForeignKey, bool validated, Action onchange) {
            Name = name;
            Value = value;
            Control = control;
            Type = type;
            Validated = validated;
            OnChange = onchange;
        }

        public string Name { get; set; }
        public Func<string> Value { get; set; }
        public Control Control { get; set; }
        public Type? Type { get; set; }
        public bool Validated { get; set; }
        public Action OnChange { get; set; }
        public MaterialDivider? ValidationPanel { get; set; }
        Action<int>? AssignForeignKey { get; set; }
    }

    public void Create<T>() where T : IDatabaseModel {
        _currentType = typeof(T);
        PreviousFormType = _currentType;

        // Store properties in cache if needed later
        PropertyInfo[] props;
        if (_propCache.ContainsKey(_currentType)) {
            props = _propCache[_currentType];
        } else {
            props = _currentType.GetProperties();
            _propCache[_currentType] = props;
        }

        var valid_props = props.Where(x => !x.CustomAttributes.Any(x => _skips.Contains(x.AttributeType))).Select(x => (x, false)).ToList();

        ToolTip tt = new ToolTip();

        foreach (var prop in valid_props) {
            var label = new MaterialLabel() { Text = prop.Item1.Name };

            tt.ToolTipIcon = ToolTipIcon.Info;
            tt.IsBalloon = false;
            tt.ShowAlways = true;

            if(Validation.HasValidationMessage(label.Text)) 
                tt.SetToolTip(label, Validation.ValidationMessage(label.Text));

            var size = TextRenderer.MeasureText(label.Text, MaterialLabel.DefaultFont);
            label.Size = size;
            label.Width += 200;
            LOG($"{prop.Item1.Name} width: {size.Width}");
            LOG($"{prop.Item1.Name} actual width: {label.Size.Width}");

            panel1.Controls.Add(label);
            var txtBox = new MaterialTextBox();

            Type? t = null;

            if (Attribute.GetCustomAttribute(prop.Item1, typeof(PrimaryKey)) != null ||
                Attribute.GetCustomAttribute(prop.Item1, typeof(InitialValueInt)) != null ||
                Attribute.GetCustomAttribute(prop.Item1, typeof(InitialValueString)) != null) {
                continue;
            }
            if (Attribute.GetCustomAttribute(prop.Item1, typeof(ForeignKeyAttribute)) != null) {
                var n = prop.Item1.Name.Split("Id")[0];
                var type = ModelHelper.ModelTypes.First(x => x.Name == n);
                t = type;
                txtBox.Tag = "foreign";
            }
            if (Attribute.GetCustomAttribute(prop.Item1, typeof(DateAttribute)) != null) {
                txtBox.Tag = "date";
            }
            if (Attribute.GetCustomAttribute(prop.Item1, typeof(ToggleAttribute)) != null) {
                txtBox.Tag = "toggle";
            }

            panel1.Controls.Add(txtBox);
            PropertyValues.Add(new(label.Text, () => txtBox.Text, txtBox, t, null, false, () => { }));
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
        int labelWidth = Math.Min(maxLabelSize.Width, availableWidthPerColumn) + 30;
        int labelHeight = maxLabelSize.Height;

        int horizontalSpacing = (horizontalSpace - (textBoxWidth * columns)) / (columns + 1);
        int verticalSpacing = (verticalSpace - (totalHeightPerRow * rows)) / (rows + 1);

        int startX = 10;
        int startY = 10;

        for (int i = 0; i < textBoxCount; i++) {
            var pb = new PictureBox();
            pb.Image = imageList1.Images[0];
            panel1.Controls.Add(pb);

            tt.SetToolTip(pb, Validation.ValidationMessage(labels[i].Text));

            int row = i / columns;
            int col = i % columns;

            int labelX = startX + horizontalSpacing + col * (textBoxWidth + horizontalSpacing);
            int labelY = startY + verticalSpacing + row * (totalHeightPerRow + verticalSpacing);

            int textBoxX = labelX;
            int textBoxY = labelY + labelHeight + 10;

            labels[i].Location = new Point(labelX, labelY);
            labels[i].Size = new Size(labelWidth, labelHeight);

            pb.Location = new Point(labelX + TextRenderer.MeasureText(labels[i].Text, MaterialLabel.DefaultFont).Width + 20, labelY);
            pb.Size = new Size(labelHeight, labelHeight);
            pb.BringToFront();

            textBoxes[i].Location = new Point(textBoxX, textBoxY);
            textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
        }

        #endregion

        #region Custom Buttons Creation and Spacing

        var obj = (IDatabaseModel)Activator.CreateInstance(typeof(T))!;
        var btns = obj.CreateButtons();

        foreach (var btn in btns) {
            var b = new MaterialButton() { Text = btn.Key, UseAccentColor = true };

            b.Click += (s, e) => btn.Value.Item1.Invoke((PropertyValues.Select(x => (x.Name, x.Value)).ToList(), _edited_object));

            OnValidationChange += () => {
                b.Enabled = PropertyValues.Count(x => x.Validated) == PropertyValues.Count;
            };

            b.Enabled = false;

            Controls.Add(b);
        }

        // TODO: Fix button spacing in create form

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

        #endregion

        #region Replace Textbox with DateTimePicker, Toggle, and ForeignKey
        foreach (var foreignkey in textBoxes.Where(x => (string)x.Tag! == "foreign")) {
            var idx = panel1.Controls.IndexOf(foreignkey);
            if (idx == -1) continue;

            var foreignkey_property_kvp = PropertyValues.First(x => x.Control == foreignkey);

            var textbox_size = panel1.Controls[idx].Size;
            var textbox_location = panel1.Controls[idx].Location;

            var foreignkey_select_button = new MaterialButton {
                Text = "Choose",
                AutoSize = false,
                Type = MaterialButton.MaterialButtonType.Outlined,
                Size = textbox_size,
                Location = textbox_location
            };

            foreignkey_select_button.Click += (s, e) => {
                ShowGCFR(typeof(FormSelectViewModel), foreignkey_property_kvp.Type!);
                var formSelectViewModel = ((Master as FormSkeleton)!.CurrentForm as FormSelectViewModel)!;

                var needed_prop_vals = PropertyValues.Select(x => (x.Name, x.Value)).ToList();
                var temp_created_obj = typeof(T).GetMethod("CreateFromList")!.Invoke(Activator.CreateInstance<T>(), [needed_prop_vals, null]);

                typeof(FormSelectViewModel).
                    GetMethod(nameof(FormSelectViewModel.SetCallbackFromSelectType))!.
                    MakeGenericMethod(typeof(T)).
                    Invoke(formSelectViewModel, [FormSelectViewModel.SelectType.GetKey, temp_created_obj]);
            };

            panel1.Controls.RemoveAt(idx);
            panel1.Controls.Add(foreignkey_select_button);

            foreignkey_property_kvp.Value = () => foreignkey_select_button.Text;
            foreignkey_property_kvp.Control = foreignkey_select_button;
            PropertyValues[PropertyValues.IndexOf(PropertyValues.First(x => x.Name == foreignkey_property_kvp.Name))] = foreignkey_property_kvp;
        }

        foreach (var textbox_datetime in textBoxes.Where(x => (string)x.Tag! == "date")) {
            var textbox_datetime_idx = panel1.Controls.IndexOf(textbox_datetime);
            if (textbox_datetime_idx == -1) continue;

            var datetime_property_kvp = PropertyValues.First(x => x.Control == textbox_datetime);


            var textbox_size = panel1.Controls[textbox_datetime_idx].Size;
            var textbox_location = panel1.Controls[textbox_datetime_idx].Location;

            var textbox_datetime_validation_panel = new MaterialDivider();
            var under = new MaterialCard();

            textbox_datetime_validation_panel.Height = textbox_size.Height - 38;
            textbox_datetime_validation_panel.Width = textbox_size.Width - 14;
            textbox_datetime_validation_panel.Location = textbox_location;
            textbox_datetime_validation_panel.Location = new(textbox_datetime_validation_panel.Location.X + 7, textbox_datetime_validation_panel.Location.Y + 20);
            textbox_datetime_validation_panel.BackColor = MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor;

            under.Height = textbox_size.Height - 35;
            under.Width = textbox_size.Width - 10;
            under.Location = textbox_location;
            under.Location = new(under.Location.X + 5, under.Location.Y + 20);

            var datetime_picker = new DateTimePicker {
                AutoSize = false,
                Size = textbox_size,
                Location = textbox_location
            };

            datetime_picker.MaxDate = DateTime.Now.AddYears(1);
            if(datetime_picker.Value < DateTime.Now) {
                datetime_picker.MinDate = datetime_picker.Value.AddDays(-1);
            } else {
                datetime_picker.MinDate = DateTime.Now.AddHours(-1);
            }

            panel1.Controls.RemoveAt(textbox_datetime_idx);
            panel1.Controls.Add(datetime_picker);
            panel1.Controls.Add(textbox_datetime_validation_panel);
            panel1.Controls.Add(under);

            // TODO editing doesnt work becaues foreign is auto invalided

            datetime_property_kvp.Value = () => datetime_picker.Value.ToString();
            datetime_property_kvp.Control = datetime_picker;
            datetime_property_kvp.ValidationPanel = textbox_datetime_validation_panel;
            datetime_property_kvp.Validated = true;
            PropertyValues[PropertyValues.IndexOf(PropertyValues.First(x => x.Name == datetime_property_kvp.Name))] = datetime_property_kvp;
        }

        foreach (var textbox_toggle in textBoxes.Where(x => (string)x.Tag! == "toggle")) {
            var textbox_toggle_idx = panel1.Controls.IndexOf(textbox_toggle);
            if (textbox_toggle_idx == -1) continue;

            var textbox_property_kvp = PropertyValues.First(x => x.Control == textbox_toggle);
            var toggle_textbox_size = panel1.Controls[textbox_toggle_idx].Size;
            var toggle_textbox_location = panel1.Controls[textbox_toggle_idx].Location;

            var checkbox = new MaterialCheckbox { AutoSize = false, Size = toggle_textbox_size, Location = toggle_textbox_location };

            panel1.Controls.RemoveAt(textbox_toggle_idx);
            panel1.Controls.Add(checkbox);

            textbox_property_kvp.Value = () => checkbox.Checked.ToString();
            textbox_property_kvp.Control = checkbox;
            textbox_property_kvp.Validated = true;
            PropertyValues[PropertyValues.IndexOf(PropertyValues.First(x => x.Name == textbox_property_kvp.Name))] = textbox_property_kvp;
        }

        #endregion

        Validations = Enumerable.Range(0, PropertyValues.Count).Select(x => false).ToList();

        LOG($"Validations count: {Validations.Count}, PropertyValues.Count: {PropertyValues.Count}");

        for (int i = 0; i < PropertyValues.Count; i++) {
            var propval = PropertyValues[i];
            Control control = propval.Control;
            if (control is MaterialTextBox textBox) {
                LOG($"Adding event for Textbox: {propval.Name}");
                textBox.TextChanged += (s, e) => {
                    propval.Validated = propval.Name switch {
                        "Forename" => (propval.Control as MaterialTextBox)!.Text.Validate(NAME),
                        "Surname" => (propval.Control as MaterialTextBox)!.Text.Validate(NAME),
                        "Name" => (propval.Control as MaterialTextBox)!.Text.Validate(NAME),
                        "Description" => (propval.Control as MaterialTextBox)!.Text.Validate(DESCRIPTION),
                        "ContactNumber" => (propval.Control as MaterialTextBox)!.Text.Validate(PHONE),
                        "BillingAddress" => (propval.Control as MaterialTextBox)!.Text.Validate(ADDRESS),
                        "Address" => (propval.Control as MaterialTextBox)!.Text.Validate(ADDRESS),
                        "Price" => (propval.Control as MaterialTextBox)!.Text.Validate(PRICE),
                        "Amount" => (propval.Control as MaterialTextBox)!.Text.Validate(QUANTITY),
                        "Quantity" => (propval.Control as MaterialTextBox)!.Text.Validate(QUANTITY),
                        _ => false,
                    };
                    if (propval.Validated)
                        textBox.UseAccent = true;
                    else
                        textBox.UseAccent = false;

                    OnValidationChange.Invoke();
                };
            }
            if (control is DateTimePicker dateTimePicker) {
                dateTimePicker.ValueChanged += (s, e) => {
                    propval.Validated = propval.Name switch {
                        "Date" => (propval.Control as DateTimePicker)!.Value.ToString().Validate(DATE),
                        "StartDate" => (propval.Control as DateTimePicker)!.Value.ToString().Validate(DATE_PAST),
                        "EndDate" => (propval.Control as DateTimePicker)!.Value.ToString().ValidateDateFuture((PropertyValues.First(x => x.Name == "StartDate").Control as DateTimePicker)!.Value.ToString()),
                        _ => false,
                    };
                    propval.ValidationPanel!.BackColor = propval.Validated ? MaterialSkin.MaterialSkinManager.Instance.ColorScheme.AccentColor : MaterialSkin.MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
                    OnValidationChange.Invoke();
                };
            }
            if (control is MaterialCheckbox checkbox) {
                checkbox.CheckedChanged += (s, e) => {
                    propval.Validated = true;
                    OnValidationChange.Invoke();
                };
            }
            if (control is MaterialButton button) {
                button.Click += (s, e) => {
                    propval.Validated = int.TryParse(propval.Value(), out _);
                    OnValidationChange.Invoke();
                };
            }
        }
    }

    // TODO: Clicking create in editing just createa  new one

    public void Populate<T>(T obj) where T : IDatabaseModel {
        var obj_props = obj!.GetType().GetProperties();

        foreach (var obj_prop in obj_props) {
            var matching_property_value = PropertyValues.FirstOrDefault(property_value => property_value.Name == obj_prop.Name);
            if (matching_property_value is null) continue;


            if (Attribute.GetCustomAttribute(obj_prop, typeof(DateAttribute)) != null) {
                if ((obj_prop.GetValue(obj, null) as string) == "") {
                    continue;
                }
                (matching_property_value.Control as DateTimePicker)!.Value = Convert.ToDateTime(obj_prop.GetValue(obj, null));
            } else if (Attribute.GetCustomAttribute(obj_prop, typeof(ToggleAttribute)) != null) {
                (matching_property_value.Control as MaterialCheckbox)!.Checked = Convert.ToBoolean(obj_prop.GetValue(obj, null));
            } else if (Attribute.GetCustomAttribute(obj_prop, typeof(ForeignKeyAttribute)) != null) {
                (matching_property_value.Control as MaterialButton)!.Text = Convert.ToString(obj_prop.GetValue(obj, null));
                matching_property_value.Validated = true;
            } else {
                (matching_property_value.Control as MaterialTextBox)!.Text = Convert.ToString(obj_prop.GetValue(obj, null));
            }
        }
        _edited_object = obj;
    }
}
