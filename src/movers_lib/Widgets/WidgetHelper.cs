using System.ComponentModel;

namespace movers_lib.Widgets;


/// <summary>
/// The flow of Widget controls
/// </summary>
public enum LayoutType
{
    Horizontal,
    Vertical
}

/// <summary>
/// The type of border on Widget
/// </summary>
public enum BorderType
{
    Container,
    Single,
    None
}

/// <summary>
/// Method of rendering the widget
/// </summary>
public enum DrawType
{
    Default,
    Optimised,
    DoubleBuffered
}

public static class WidgetHelper
{
    public static Font DefaultFont = new Font(FontFamily.GenericMonospace, 20);
    public static void AddComponent(this IWidget widget, IComponent component)
    {
        widget.Components.Add(component);
    }
}
