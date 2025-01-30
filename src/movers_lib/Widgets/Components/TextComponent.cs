
namespace movers_lib.Widgets.Components;

public class TextComponent : IComponent
{
    public bool Centered { get; set; } = true;
    public bool Enabled { get; set; } = true;
    public Font Font { get; set; } = new Font(FontFamily.GenericMonospace, 20);
    public string Text { get; set; } = "Null";

    public TextComponent(string text, Font font)
    {
        Text = text;
        Font = font;
    }

    public void Render(Graphics g, Rectangle r)
    {
        g.DrawString(Text, Font, Brushes.Black, r.X, r.Y);
    }
}
