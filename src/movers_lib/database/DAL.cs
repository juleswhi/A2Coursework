using Microsoft.Data.Sqlite;
using movers_lib;
namespace database;

public class DAL
{
    public static void Connect()
    {
        using var connection = new SqliteConnection($"Data Source={PathHelper.DatabaseString}");

        connection.Open();

        using var command = connection.CreateCommand();

        command.CommandText = "insert into department(1, \"Cleaning\")";

        command.ExecuteNonQuery();

        LOG($"Executed command");
    }
}
