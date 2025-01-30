namespace movers_lib.forms;

using movers_lib.model;
using movers_lib.View;

public static class FormManager
{
    private static IFormMaster? _master;

    public static IFormMaster? GetMaster()
    {
        return _master;
    }

    public static Size MasterSize => (_master as FormMaster)!.Size;

    public static void ChangeMasterSize(int width, int height)
    {
        var m = _master as FormMaster;
        m!.Width = width;
        m!.Height = height;
        LOG($"NEW WIDTH: {m.Width}, NEW HEIGHT: {m.Height}");
    }

    public static void CenterMaster()
    {
        var m = _master as FormMaster;
        m!.Location = new Point((Screen.PrimaryScreen!.WorkingArea.Width - m!.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - m!.Height) / 2);
    }

    public static void Start<T>(Action<FormMaster>? callback = null) where T : Form, new()
    {
        _master = new FormMaster();

        Trigger<T>();

        if (callback is Action<IFormMaster> action)
        {
            action(_master);
        }

        Application.Run((FormMaster)_master);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void Trigger<T>() where T : Form, new()
    {
        if (_master is null) return;

        T form = CreateForm<T>();

        _master.LoadForm(form);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void Trigger<T, V>() where T : Form, new() where V : DatabaseModel
    {
        if (_master is null) return;

        T form = CreateForm<T>();

        _master.LoadForm(form);

        (form as GenericCreateableForm)!.Create<V>();
    }

    /// <summary>
    /// Creates a form from a type, and attempts to pass state through 
    /// </summary>
    /// <typeparam name="T">The type of form to create</typeparam>
    /// <returns>The form object</returns>
    private static T CreateForm<T>() where T : Form, new() => Activator.CreateInstance<T>();
}