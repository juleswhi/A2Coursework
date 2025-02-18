using Forms;
using MaterialSkin.Controls;
using Model;

namespace View;

public partial class FormCreate : Form, GenericCreateableForm
{
    private Type? _currentType;
    private List<MaterialTextBox> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().ToList();
    private bool _editMode = false;
    public FormCreate()
    {
        InitializeComponent();
        btnBack.UseAccentColor = true;
        btnCreate.UseAccentColor = true;

        btnCreate.Enabled = false;
    }

    public void Create<T>() where T : DatabaseModel
    {
        // Get fields in type
        var props = typeof(T).GetProperties();

        foreach (var prop in props)
        {
            if (prop.Name == "Id") continue;

            panel1.Controls.Add(new MaterialTextBox());
            panel1.Controls.Add(new MaterialLabel() { Text = prop.Name });
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

        // Calculate the total height required for each row (label + textbox + spacing)
        int totalHeightPerRow = maxLabelSize.Height + maxTextBoxSize.Height + 10; // 10 is spacing between label and textbox

        // Calculate the available width and height per column/row
        int availableWidthPerColumn = horizontalSpace / columns;
        int availableHeightPerRow = verticalSpace / rows;

        // Determine the actual size of each textbox and label
        int textBoxWidth = Math.Min(maxTextBoxSize.Width, availableWidthPerColumn);
        int textBoxHeight = Math.Min(maxTextBoxSize.Height, availableHeightPerRow - maxLabelSize.Height - 10); // Account for label height and spacing
        int labelWidth = Math.Min(maxLabelSize.Width, availableWidthPerColumn);
        int labelHeight = maxLabelSize.Height;

        // Calculate the spacing between controls
        int horizontalSpacing = (horizontalSpace - (textBoxWidth * columns)) / (columns + 1);
        int verticalSpacing = (verticalSpace - (totalHeightPerRow * rows)) / (rows + 1);

        // Position the labels and textboxes
        int startX = 10;
        int startY = 10;

        for (int i = 0; i < textBoxCount; i++)
        {
            int row = i / columns;
            int col = i % columns;

            // Calculate the position for the label
            int labelX = startX + horizontalSpacing + col * (textBoxWidth + horizontalSpacing);
            int labelY = startY + verticalSpacing + row * (totalHeightPerRow + verticalSpacing);

            // Calculate the position for the textbox
            int textBoxX = labelX;
            int textBoxY = labelY + labelHeight + 10; // 10 is spacing between label and textbox

            // Set the location and size of the label and textbox
            labels[i].Location = new Point(labelX, labelY);
            labels[i].Size = new Size(labelWidth, labelHeight);

            textBoxes[i].Location = new Point(textBoxX, textBoxY);
            textBoxes[i].Size = new Size(textBoxWidth, textBoxHeight);
        }




        _currentType = typeof(T);
        _textBoxes.ForEach(x => x.TextChanged += (s, e) =>
        {
            btnCreate.Enabled = _textBoxes.All(y => y.Text != String.Empty);
        });
    }

    public void Populate<T>(T obj)
    {
        obj!.GetType().GetProperties().Zip(_textBoxes).ToList().ForEach(x =>
        {
            x.Second.Text = Convert.ChangeType(x.First.GetValue(obj), x.First.PropertyType)!.ToString();
        });
        _editMode = true;
        btnCreate.Text = "Update";
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        var method = typeof(FormManager)!.GetMethod(nameof(ShowGCF));
        var generic = method!.MakeGenericMethod(typeof(FormViewModel), _currentType!);
        generic.Invoke(null, null);
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        if (_editMode)
        {
            var delete_meth = typeof(DAL).GetMethod(nameof(DAL.Delete))!.MakeGenericMethod(_currentType!);
            delete_meth.Invoke(null, [$"Id = {_textBoxes[0].Text}"]);
        }
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
