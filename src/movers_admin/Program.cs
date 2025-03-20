namespace movers_admin;

using MaterialSkin;
using System.Diagnostics;
using View;
using static Forms.FormManager;

internal static class Program {

    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();

        // Set colourscheme
        MaterialSkinManager.Instance.ColorScheme = new ColorScheme(Primary.Brown400, Primary.Brown200, Primary.Brown700, Accent.Teal400, TextShade.BLACK);

        // Start form using my own Form Management System rather than the default way
        Start<FormHome>();
    }
}

public class Example {
    public int Id { get; set; }
}