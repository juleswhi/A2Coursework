using MaterialSkin.Controls;
using movers_lib.forms;
using movers_lib.model;

namespace movers_lib.View;

public partial class FormCreate : Form, GenericCreateableForm
{
    private Type? _currentType;
    private List<(MaterialTextBox, bool)> _textBoxes => panel1.Controls.OfType<MaterialTextBox>().Select(x => (x, false)).ToList();
    public FormCreate()
    {
        InitializeComponent();
        btnBack.UseAccentColor = true;
        btnCreate.UseAccentColor = true;

        _textBoxes.ForEach(x => x.Item1.TextChanged += (s, e) =>
        {
            btnCreate.Enabled = _textBoxes.All(y => y.Item2);
        });
    }

    public void Create<T>() where T : DatabaseModel
    {
        // Get fields in type
        var props = typeof(T).GetProperties();

        var location = (panel1.Width / 3, 10);

        var max_len = props.Select(x => TextRenderer.MeasureText(x.Name, MaterialButton.DefaultFont).Width).Order().Reverse().First();

        foreach (var prop in props)
        {
            var btn = new MaterialTextBox();
            var label = new MaterialLabel();
            label.Text = prop.Name;
            btn.Location = new(location.Item1, location.Item2);
            label.Location = new(location.Item1 - max_len - 25, location.Item2 + 15);

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
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        var method = typeof(FormManager)!.GetMethod(nameof(ShowGCF));
        var generic = method!.MakeGenericMethod(typeof(FormViewModel), _currentType!);
        generic.Invoke(null, null);
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {

    }
}
