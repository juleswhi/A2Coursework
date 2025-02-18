using System.Reflection;

namespace movers_lib.writeup_tools;

public static class StoryboardConverter {
    public static void Convert() {
        var assembly = Assembly.GetCallingAssembly();

        var types = assembly.GetTypes();

        Type form = typeof(Form);

        var forms = types.Where(x => x.IsSubclassOf(form) || x == form);

        using var sw = new StreamWriter(@"examplepath.txt", true);

        foreach (Type type in forms) {
            // Create the instance of the form
            var instance = Activator.CreateInstance(type);

            PrintContainer(instance, sw);
        }

        LOG($"DONE");

        // Collect all that garbage from potentially large amount of objects created
        GC.Collect();

    }

    private static void PrintContainer<T>(T obj, StreamWriter sw) {
        var controls = GetControls(obj);

        if (controls is null) {
            return;
        }

        foreach (Control control in controls) {
            if (control is Panel || control.GetType().IsSubclassOf(typeof(Panel))) {
                // Get controls of panel
                PrintContainer(control, sw);
            }

            foreach (var str in GetInformation(control)) {
                sw.WriteLine(str);
            }
        }
    }

    private static Control.ControlCollection? GetControls<T>(T obj) {
        var type = typeof(T);
        var controlProp = type.GetProperty("Controls");

        if (controlProp is null) {
            return null;
        }

        Control.ControlCollection? controls = controlProp.GetValue(obj) as Control.ControlCollection;

        if (controls is null) {
            return null;
        }

        return controls;
    }

    private static IEnumerable<string> GetInformation<T>(T control) where T : Control {
        var props = control.GetType().GetProperties();

        foreach (var prop in props) {
            string str;
            try {
                // Grab the value of the property
                str = $"\t\t{prop.Name}: {PrettyPrint(prop.GetMethod?.Invoke(control, new object[] { }))}";
            } catch (Exception) {
                // Some weird property values may encounter this exception
                // In that case, just ignore it
                continue;
            }

            yield return str;
        }
    }

    private static string? PrettyPrint(object? obj) {
        if (obj is Font font) {
            return $"{font.Name} - {font.Size}px";
        }

        if (obj is Point point) {
            return $"[{point.X}, {point.Y}]";
        }

        if (obj is Size size) {
            return $"[{size.Width}, {size.Height}]";
        }

        return (string?)obj;
    }
}
