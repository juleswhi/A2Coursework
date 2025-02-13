using Microsoft.Data.SqlClient;
using Model;
namespace Database;

/// <summary>
/// Database Access Layer
/// Manages all Database Operations, including Queries, Creating, Deleting, Updating
/// </summary>
public static class DAL
{
    /// <summary>
    /// Connection string : Refactor
    /// </summary>
    // private static readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\callum white\projects\movers_admin\movers_lib\database\database.mdf';Integrated Security=True";
    private static readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\callum\Documents\GitHub\A2Coursework\src\movers_lib\database\database.mdf';Integrated Security=True";

    /// <summary>
    /// Query a database via class (and with selected column names)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="names"></param>
    /// <returns></returns>
    public static List<T> Query<T>(params string[] names) where T : DatabaseModel
    {
        var type = typeof(T);

        // If no column names are passed then grab all of them
        if (names is null || names.Length == 0) {
            names = type.GetProperties().Select(x => x.Name).ToArray();
        }

        string name = names.Aggregate((x, y) => $"{x}, {y}");
        // Id and Forename

        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();
        using var command = new SqlCommand($"select {name} from {type.Name} ;", conn);

        // Grab results from query
        using var reader = command.ExecuteReader();

        List<T> results = [];

        while(reader.Read())
        {
            // Create instance of the DatabaseModel
            T obj = Activator.CreateInstance<T>();
            foreach (var property in type.GetProperties().Where(x => names.Contains(x.Name)))
            {
                // Grab the column cooresponding to the name
                var ord = reader.GetOrdinal(property.Name);

                // No nulls are ever allowed in database
                ASSERT(!reader.IsDBNull(ord));

                var t = property.PropertyType;

                // Properly cast to type based on SQL type
                switch (property.PropertyType.Name)
                {
                    case "Int32":
                    case "System.Int32":
                        var num = reader.GetInt32(ord);
                        var prop = type.GetProperty(property.Name);
                        if(prop is null)
                            break;
                        prop.SetValue(obj, num);
                        break;
                    case "Double":
                        var doub = reader.GetInt32(ord);
                        var p = type.GetProperty(property.Name);
                        if(p is null)
                            break;
                        p.SetValue(obj, doub);
                        break;
                    case "DateTime":
                        var dt = reader.GetDateTime(ord);
                        type.GetProperty(property.Name)!.SetValue(obj, dt);
                        break;
                    case "Boolean":
                        var b = reader.GetBoolean(ord);
                        type.GetProperty(property.Name)!.SetValue(obj, b);
                        break;
                    default:
                        var str = reader.GetString(ord);
                        type.GetProperty(property.Name)!.SetValue(obj, str);
                        break;
                };
            }
            results.Add(obj);
        }

        conn.Close();

        return results;
    }

    // public static List<T> Query<T>(Func<T, bool> func, params string[] names) where T : DatabaseModel => Query<T>(names).Where(func).ToList();

    /// <summary>
    /// Update SQL statement
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="rec"></param>
    /// <returns></returns>
    public static bool Update<T>(this T obj, string rec) where T : DatabaseModel {
        var type = typeof(T);

        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();

        string updates = type.GetProperties().Select(x => x.Name)
            .Zip(type.GetProperties()
                .Select(x => x.GetValue(obj))
                .Select(y => y == null ? "" : y.ToString()))
            .Select((c, _) => $"{c.First} = '{c.Second}'")
            .Aggregate((x, y) => $"{x}, {y}");

        using var command = new SqlCommand($"update {type.Name} set {updates} where {rec};", conn);
        int res = command.ExecuteNonQuery();

        conn.Close();

        return res == 0;
    }

    public static bool Delete<T>(string condition) where T : DatabaseModel
    {
        var type = typeof(T);

        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();

        using var command = new SqlCommand($"delete from {type.Name} where {condition};", conn);
        return command.ExecuteNonQuery() == 0;
    }

    public static bool Create<T>(this T obj) where T : DatabaseModel
    {
        var type = typeof(T);
        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();

        string props = type.GetProperties().
            Select(x => x.Name).
            Aggregate((x, y) => $"{x}, {y}");
        string vals = type.GetProperties().
            Select(x => x.GetValue(obj)).
            Select(x => x!.ToString()).
            Select(x => x!.Replace("'", "''")).
            Aggregate((x, y) => $"{x}, '{y}'")!;

        using var command = new SqlCommand($"insert into {type.Name} ({props}) values ({vals})", conn);

        LOG($"insert into {type.Name} ({props}) values ({vals})");

        return command.ExecuteNonQuery() == 0;
    }
}
