using movers_lib.Widgets.Components;
using System.Windows.Forms.Design;

namespace movers_lib.Widgets;

public class TextWidget : IWidget
{
    public List<IComponent> Components { get; set; } =
        [new TextComponent("title", DefaultFont) { Centered = false }, new TextComponent("body", DefaultFont) { Centered = false }];
    public BorderType BorderType { get; set; } = BorderType.None;
    public LayoutType LayoutType { get; set; } = LayoutType.Vertical;
    public DrawType DrawType { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public int Padding { get; set; } = 5;
    public void Render(Graphics g, Rectangle r)
    {
        var pointer = (r.X, r.Y);

        foreach (var component in Components)
        {
            var c = (TextComponent)component;

            var component_size = TextRenderer.MeasureText(c.Text, c.Font);

            if (component_size.Width - pointer.Item1 > r.Width || component_size.Height - pointer.Item2 > r.Height) {
                g.DrawString("INVALID ELEMENT", DefaultFont, Brushes.Black, r.X, r.Y);
                return;
            }

            var component_rectangle = new Rectangle(pointer.Item1, pointer.Item2, component_size.Width, component_size.Height);

            if (component.Centered && LayoutType != LayoutType.Horizontal)
            {
                var centered = (int)(0.5 * r.Width) - (int)(0.5 * component_size.Width);
                pointer.X = centered;
                component_rectangle.X = centered;
            }

            if (BorderType == BorderType.Single)
            {
                g.DrawRectangle(Pens.Red, component_rectangle);
            } 

            component.Render(g, component_rectangle);


            if (LayoutType == LayoutType.Vertical)
            {
                pointer = (pointer.Item1, pointer.Item2 + component_rectangle.Height + Padding);
            }
            else if (LayoutType == LayoutType.Horizontal)
            {
                pointer = (pointer.Item1 + component_rectangle.Width + Padding, pointer.Item2);
            }
        }
    }
}
