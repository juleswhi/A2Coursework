namespace movers_admin;

using database;
using MaterialSkin;
using MaterialSkin.Controls;
using movers_lib.forms;
using movers_lib.model;
using movers_lib.View;
using System.Diagnostics;
using static movers_lib.forms.FormManager;
using static movers_lib.logging.Logger;
using static movers_lib.PathHelper;

using static state.StateHelper;
using static state.StateType;

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