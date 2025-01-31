using MaterialSkin.Controls;
using movers_lib.model;

namespace movers_lib.View;

public partial class FormCreate : Form, GenericCreateableForm
{
    public FormCreate()
    {
        InitializeComponent();
    }

    public void Create<T>() where T : DatabaseModel
    {
        // Get fields in type
        var props = typeof(T).GetProperties();

        var location = (Width / 2, 40);

        foreach (var prop in props)
        {
            var btn = new MaterialTextBox();
            var label = new MaterialLabel();
            label.Text = prop.Name;
            btn.Location = new(location.Item1, location.Item2);
            label.Location = new(location.Item1 - 200, location.Item2);

            // Check below height

            location.Item2 = location.Item2 + btn.Height + 10;
            Controls.Add(btn);
            Controls.Add(label);
        }
    }
}
