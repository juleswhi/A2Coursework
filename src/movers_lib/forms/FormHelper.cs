namespace movers_lib.forms;

// Contains a bunch of extension methods
public enum ControlDirection
{
    X,
    Y
}

public static class FormHelper
{
    public static void Center(this Control control, ControlDirection controlDirection)
    {
        switch (controlDirection)
        {
            case ControlDirection.X:
                control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)), control.Location.Y);
                break;

            case ControlDirection.Y:
                control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height));
                break;
        }
    }

    public static void Center(this Control control)
    {
        control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)), control.Location.Y);
        control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height));
    }

    public static void Center(this Control control, int x, int y)
    {
        control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)), control.Location.Y);
        control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height));
    }

    public static void CenterX(this Control control)
    {
        control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)), control.Location.Y);
    }

    public static void CenterY(this Control control)
    {
        control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height));
    }

    public static void CenterX(this Control control, int x)
    {
        control.Location = new Point((int)((control.Parent!.Width / 2) - 0.5 * (control.Width)) + x, control.Location.Y);
    }

    public static void CenterY(this Control control, int y)
    {
        control.Location = new Point(control.Location.X, (int)((control.Parent!.Height / 2) - 0.5 * control.Height) - y);
    }

    public static void InitResizeable<T>(this T form, EventHandler action) where T : Form, IResizeable
    {
        form.OnViewPortChanged();
        LOG("In init resizable");
        action += (s, e) =>
        {
            form.OnViewPortChanged();
        };
    }

    public static Color GetBlue() => Color.FromArgb(255, 57, 49, 134);

}