using movers_lib;
using movers_lib.forms;

namespace controls;

public class HalfPanel : Panel, IResizeableControl
{
    public HalfPanel() : base()
    {
        BackColor = GetBlue();
        BackgroundImageLayout = ImageLayout.Center;
    }

    public void OnViewPortChanged(Size new_size)
    {
        Size = new Size(new_size.Width / 2, new_size.Height);
        this.CenterX(new_size.Width / 4);
    }

    private void InitializeComponent()
    {
        SuspendLayout();
        // 
        // HalfPanel
        // 
        ResumeLayout(false);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;

        var img = images.MoversCompanyLogo;

        var x = Width - (int)(0.5 * Width) - 275;
        var y = Height - (int)(0.5 * Height) - 237;

        g.DrawImage(img, new Rectangle(x, y , 550, 475), new(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
    }
}
