namespace movers_lib.Widgets;

public interface IWidget 
{
    public List<IComponent> Components { get; set; }
    public BorderType BorderType { get; set; }
    public LayoutType LayoutType { get; set; }
    public DrawType DrawType { get; set; }

    public double X { get; set; }
    public double Y { get; set; }

    public int Padding { get; set; }

    public void Render(Graphics g, Rectangle r);
}
