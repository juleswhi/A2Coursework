namespace movers_lib;

public static class PathHelper
{
    public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\MoversAdmin";
    public static string DatabaseString = Path.Join(AppData, "movers_db.db");
    public static void SetupAppData() {
        Directory.CreateDirectory(AppData);

        if (!File.Exists(DatabaseString)) {
            File.Create(DatabaseString);
        }
    }
}
