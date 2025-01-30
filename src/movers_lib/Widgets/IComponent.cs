namespace movers_lib.Widgets;

public interface IComponent
{
    public bool Centered { get; set; }
    public bool Enabled { get; set; }
    public void Render(Graphics g, Rectangle r);
}
