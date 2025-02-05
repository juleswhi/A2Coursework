namespace movers_admin;

using database;
using movers_lib.logging;
using MaterialSkin;
using Microsoft.VisualBasic.Logging;
using movers_lib.model;
using movers_lib.View;
using static movers_lib.forms.FormManager;
using static movers_lib.PathHelper;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

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