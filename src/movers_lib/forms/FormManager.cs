namespace Forms;

using Model;
using View;

public static class FormManager
{
    public static IFormMaster? Master;
    public static Size MasterSize => (Master as Form)!.Size;

    public static void ChangeMasterSize(int width, int height)
    {
        var m = Master as Form;
        m!.Width = width;
        m!.Height = height;
    }

    public static void CenterMaster()
    {
        var m = Master as Form;
        m!.Location = new Point((Screen.PrimaryScreen!.WorkingArea.Width - m!.Width) / 2,
                                      (Screen.PrimaryScreen.WorkingArea.Height - m!.Height) / 2);
    }

    public static void Start<T>() where T : Form, new()
    {
        Master = new FormSkeleton();

        ShowForm<T>();

        Application.Run((FormSkeleton)Master);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void ShowForm<T>() where T : Form, new()
    {
        if (Master is null) return;

        T form = CreateForm<T>();

        Master.LoadForm(form);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void ShowGCF<T, V>() where T : Form, GenericCreateableForm, new() where V : DatabaseModel
    {
        if (Master is null) return;

        T form = CreateForm<T>();

        Master.LoadForm(form);

        form.Create<V>();
    }

    /// <summary>
    /// Show GCF but reflective
    /// </summary>
    /// <param name="T">Form Type To Show</param>
    /// <param name="V">Type of Database Model</param>
    public static void ShowGCFR(Type T, Type V)
    {
        if (Master is null) return;

        var method = typeof(FormManager)!.
            GetMethod(nameof(ShowGCF))!.
            MakeGenericMethod(T, V).
            Invoke(null, null);
    }

    /// <summary>
    /// Creates a form from a type, and attempts to pass state through 
    /// </summary>
    /// <typeparam name="T">The type of form to create</typeparam>
    /// <returns>The form object</returns>
    private static T CreateForm<T>() where T : Form, new() => Activator.CreateInstance<T>();
}