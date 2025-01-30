using movers_lib.forms;
using movers_lib.Widgets;
using movers_lib.Widgets.Components;

namespace movers_lib.View;

public partial class FormMain : Form, IResizeable
{
    public FormMain()
    {
        InitializeComponent();
        Controls.AddRange([
            // half_panel
            // container
        ]);

        Resize += (s, e) =>
        {
            OnViewPortChanged();
        };

        container.Add([new TextWidget()
        {
            X = 0.5,
            Y = 0.5,
        }]);

        container.Dock = DockStyle.Fill;
        container.LayoutType = LayoutType.Vertical;

        // (container.Widgets[0].Components[0] as TextComponent)!.Text = "First";
        // (container.Widgets[0].Components[1] as TextComponent)!.Text = "Second";

        // container.Render();
    }

    private HalfPanel half_panel = new();
    private Container container = new();

    public void OnViewPortChanged()
    {
        // half_panel.OnViewPortChanged(Size);
        Refresh();
        container.Render();
    }
}
