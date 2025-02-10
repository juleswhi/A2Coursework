using Database;
using MaterialSkin.Controls;
using Forms;
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

        var location = (panel1.Width / 2, 10);

        var max_len = props.Select(x => TextRenderer.MeasureText(x.Name, MaterialButton.DefaultFont).Width).Order().Reverse().First();

        foreach (var prop in props)
        {
            var btn = new MaterialTextBox();
            var label = new MaterialLabel();
            label.Text = prop.Name;
            btn.Location = new(location.Item1, location.Item2);
            label.Location = new(location.Item1 - max_len - 40, location.Item2 + 15);

            location.Item2 = location.Item2 + btn.Height + 10;

            if (location.Item2 > panel1.Height)
            {
                location.Item2 = 10;
                location.Item1 += 225;
            }

            panel1.Controls.Add(btn);
            panel1.Controls.Add(label);
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
        if(_editMode)
        {
            var delete_meth = typeof(DAL).GetMethod(nameof(DAL.Delete))!.MakeGenericMethod(_currentType!);
            delete_meth.Invoke(null, [$"Id = {_textBoxes[0].Text}"]);
        }
        if (_currentType is null) return;

        var obj = Activator.CreateInstance(_currentType);
        Convert.ChangeType(obj, _currentType);

        var props = _currentType.GetProperties();
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
