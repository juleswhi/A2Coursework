using movers_lib.forms;

namespace movers_lib.View;

public partial class FormMain : Form, IResizeable
{
    public FormMain()
    {
        InitializeComponent();
        Controls.AddRange([
            half_panel
        ]);

        Resize += (s, e) =>
        {
            OnViewPortChanged();
        };
    }

    private HalfPanel half_panel = new();

    public void OnViewPortChanged()
    {
        half_panel.OnViewPortChanged(Size);
    }
}
