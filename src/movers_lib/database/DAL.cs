using Microsoft.Data.SqlClient;
using movers_lib.model;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
namespace database;

public static class DAL
{
    private static readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\callum white\projects\movers_admin\movers_lib\database\database.mdf';Integrated Security=True";

    public static List<T> Query<T>(params string[] names)
    {
        var type = typeof(T);
        if (names is null || names.Length == 0) {
            names = type.GetProperties().Select(x => x.Name).ToArray();
        }

        string name = names.Aggregate((x, y) => $"{x}, {y}");

        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();
        using var command = new SqlCommand($"select {name} from {type.Name} ;", conn);
        using var reader = command.ExecuteReader();

        List<T> results = [];

        while(reader.Read())
        {
            T obj = Activator.CreateInstance<T>();
            foreach (var property in type.GetProperties().Where(x => names.Contains(x.Name)))
            {
                var ord = reader.GetOrdinal(property.Name);
                ASSERT(!reader.IsDBNull(ord));

                var t = property.PropertyType;

                LOG($"Property Name: {property.Name}, Property Type: {property.PropertyType.Name}");

                switch (property.PropertyType.Name)
                {
                    case "Int32":
                        var num = reader.GetInt32(ord);
                        var prop = type.GetProperty(property.Name);
                        if(prop is null)
                        {
                            LOG($"Property: {t.Name} is null");
                            break;
                        }
                        prop.SetValue(obj, num);
                        break;
                    case "DateTime":
                        var dt = reader.GetDateTime(ord);
                        type.GetProperty(property.Name)!.SetValue(obj, dt);
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

    public static List<T> Query<T>(Func<T, bool> func, params string[] names) => Query<T>(names).Where(func).ToList();

    public static bool Update<T>(this T obj, string rec) {
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

    public static bool Delete<T>(this T obj, string condition)
    {
        var type = typeof(T);

        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();

        using var command = new SqlCommand($"delete from {type.Name} where {condition};", conn);
        return command.ExecuteNonQuery() == 0;
    }

    public static bool Create<T>(this T obj)
    {
        var type = typeof(T);
        using var conn = new SqlConnection($"{_connectionString}");
        conn.Open();

        string props = type.GetProperties().Select(x => x.Name).Aggregate((x, y) => $"{x}, {y}");
        string vals = type.GetProperties().Select(x => x.GetValue(obj)).Select(x => x!.ToString()).Aggregate((x, y) => $"{x}, '{y}'")!;

        using var command = new SqlCommand($"insert into {type.Name} ({props}) values ({vals})", conn);

        LOG($"insert into {type.Name} ({props}) values ({vals})");

        return command.ExecuteNonQuery() == 0;
    }
}
