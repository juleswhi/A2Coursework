namespace movers_admin;

using MaterialSkin;
using View;
using static Forms.FormManager;

internal static class Program
{

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Set colourscheme
        MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green800, Primary.Green800, Accent.Teal700, TextShade.BLACK);

        // Start form using my own Form Management System rather than the default way
        Start<FormHome>();
    }
}