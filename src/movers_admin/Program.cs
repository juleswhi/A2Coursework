namespace movers_admin;

using MaterialSkin;
using movers_lib.View;
using static movers_lib.forms.FormManager;
using static movers_lib.PathHelper;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Set colourscheme
        MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Primary.Blue300, Primary.BlueGrey900, Primary.Blue300, Accent.Blue700, TextShade.BLACK);

        SetupAppData();

        // Start form using my own Form Management System rather than the default way
        Start<FormLogin>();
    }
}