using View;

namespace movers_lib.View;

public partial class Startup : Form
{
    private const int FRAME_DELAY = 1;
    private double progress = 0;
    private const double max_progress = 100;
    private const int PROGRESS_PAUSE = 200;
    private Font font = new Font(FontFamily.GenericMonospace, 40, FontStyle.Bold);
    private double percentage_across = 0;
    public Startup()
    {
        InitializeComponent();

        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        (Master as Form)!.FormBorderStyle = FormBorderStyle.None;

        Task.Run(() => ShowLoading());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

        base.OnPaint(e);

        var g = e.Graphics;

        // var img = images.MoversCompanyLogo;

        // g.DrawImage(img, new Rectangle(half_x - 200, half_y - 188, 400, 375), new(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);

        // var text_size = TextRenderer.MeasureText("Loading..", font);
        // TextFormatFlags flags = TextFormatFlags.Bottom;
        // TextRenderer.DrawText(g, "Loading..", font, new Rectangle(half_x - (int)(0.5 * text_size.Width), half_y - (int)(0.5 * text_size.Height), text_size.Width, text_size.Height), SystemColors.ControlText, flags);
    }

    public async Task ShowLoading(int duration = 1000)
    {
        while (percentage_across < 1)
        {
            await Task.Delay(FRAME_DELAY);

            percentage_across += 0.01;

            // Invoke(() => IncrementMasterSize(1, 0));
            // Invoke(Refresh);
            // Invoke(CenterMaster);
        }

        // Pause with the loading bar full
        await Task.Delay(PROGRESS_PAUSE);

        (Master as Form)!.FormBorderStyle = FormBorderStyle.FixedSingle;

        Invoke(() => ShowForm<FormSkeleton>());
    }
}
