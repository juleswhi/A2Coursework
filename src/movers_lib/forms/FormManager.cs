namespace Forms;

using Model;
using QuestPDF.Infrastructure;
using View;
using WinFormsScraper;
using static WinFormsScraper.ScrapeType;

public static class FormManager {
    ///<summary>
    /// This holds a public reference to the current main form
    ///</summary>
    public static IFormMaster? Master;

    /// <summary>
    /// This creates an instance of the master form, and displays the form T inside of it
    /// </summary>
    /// <typeparam name="T">The type of form to display</typeparam>
    public static void Start<T>() where T : Form, new() {
        Master = new FormSkeleton();

        QuestPDF.Settings.License = LicenseType.Community;

        ShowForm<T>();

        WinFormsScraper.Scrape(ALL);

        Application.Run((FormSkeleton)Master);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void ShowForm<T>() where T : Form, new() {
        if (Master is null) return;

        T form = CreateForm<T>();

        Master.LoadForm(form);
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <returns>A state representing either a Success or Failure</returns>
    public static void ShowGCF<T, V>() where T : Form, GenericCreateableForm, new() where V : IDatabaseModel {
        if (Master is null) return;

        T form = CreateForm<T>();

        Master.LoadForm(form);

        form.Create<V>();
    }

    public static void ShowGCFView<T, V>(List<V> list) where T : Form, GenericCreateableForm, new() where V : IDatabaseModel {
        if (Master is null) return;
        T form = CreateForm<T>();

        Master.LoadForm(form);

        (Master.CurrentlyDisplayedForm as FormViewModel)!.RecordsShown = list.Select(x => (IDatabaseModel)x).ToList();
        form.Create<V>();
    }

    /// <summary>
    /// Show GCF but reflective
    /// </summary>
    /// <param name="T">Form Type To Show</param>
    /// <param name="V">Type of Database Model</param>
    public static void ShowGCFR(Type T, Type V) {
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