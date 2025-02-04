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

        List<string> list = ["Rory", "James", "Michael", "Amy"];

        List<string> cool_names = list.Where(name => name[0] == 'R' || name[0] == 'J').ToList();

        // Start form using my own Form Management System rather than the default way
        Start<FormLogin>();
    }
}