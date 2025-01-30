namespace movers_lib.Widgets;

public partial class Container : UserControl
{
    public int MaxWidgetX { get; set; }
    public int MaxWidgetY { get; set; }
    public int MinSize { get; set; }
    public int MaxSize { get; set; }
    public BorderType DefaultBorderType { get; set; }
    public LayoutType LayoutType { get; set; }

    public List<IWidget> Widgets { get; set; } = [];

    public Container()
    {
        InitializeComponent();
    }

    public void Add(IWidget widget)
    {
        Widgets.Add(widget);
    }

    public void Add(IWidget[] _widgets)
    {
        foreach(var w in _widgets)
        {
            Add(w);
        }
    }

    public bool Remove(IWidget widget)
    {
        return Widgets.Remove(widget);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        var g = e.Graphics;

        (int, int) pointer = (0, 0);

        foreach(var w in Widgets)
        {
            var r = new Rectangle(pointer.Item1, pointer.Item2, (int)(w.X * Width), (int)(w.Y * Height));

            if (LayoutType == LayoutType.Horizontal)
            {
                pointer = (pointer.Item1 + r.Width, pointer.Item2);
                if(pointer.Item1 > Width)
                {
                    pointer.Item1 = 0;
                    pointer.Item2 = pointer.Item2 + r.Height;
                }
            }
            else
            {
                pointer = (pointer.Item1, pointer.Item2 + r.Height);
                if(pointer.Item2 > Height)
                {
                    LOG($"BIGGER THAN HEIGHT");
                    pointer.Item1 = pointer.Item1 + r.Width;
                    pointer.Item2 = 0;
                }
            }
            // g.DrawEllipse(Pens.AliceBlue, r);

            // g.DrawRectangle(Pens.Orange, r);

            w.Render(g, r);
        }
    }

    public void Render()
    {
        Refresh();
    }
}
