using View;

namespace Model;

public class Clean : IDatabaseModel {

    [PrimaryKey]
    public int Id { get; set; }


    [ForeignKeyAttribute(typeof(Customer))]
    public int CustomerId { get; set; }

    [DateAttribute]
    [InitialValueDate]
    public string BookDate { get; set; } = String.Empty;

    // TODO: Fix date not working properly in FormCreate
    [DateAttribute]
    public string StartDate { get; set; } = String.Empty;

    [DateAttribute]
    public string EndDate { get; set; } = String.Empty;

    public double Price { get; set; }

    [ToggleAttribute]
    public bool Paid { get; set; }

    public static Clean GenerateFakeData()
        => new Faker<Clean>()
            .RuleFor(o => o.Id, f => DAL.Query<Clean>().Select(o => o.Id).Max() + 1)
            .RuleFor(o => o.CustomerId, f => f.PickRandom(DAL.Query<Customer>().Select(x => x.Id)))
            .RuleFor(o => o.BookDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.StartDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.EndDate, f => f.Date.Future().ToString())
            .RuleFor(o => o.Price, f => f.Random.Number(0, 10_000))
            .RuleFor(o => o.Paid, f => f.Random.Bool())
            .Generate();

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
            }, false) },
            { "Edit", (m => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().
                    GetMethod(nameof(form.Populate))!.
                    MakeGenericMethod(typeof(Clean)!);
                    form_meth.Invoke(form, [m]);
            }, true) },
            { "Delete", (m => {
                    DAL.Delete((Clean)m!);
                    ShowGCF<FormViewModel, Clean>();
            }, true) }
        };
    }

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (new Action<(List<(string, Func<string>)>, IDatabaseModel?)>(list => {
                    var clean = (Clean)CreateFromList(list.Item1, list.Item2)!;

                    clean?.Delete();

                    clean?.Create();

                    ShowGCFR(typeof(FormViewModel), typeof(Clean));

            }), true) },
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var clean = new Clean();
        var cleans = DAL.Query<Clean>();

        if (!cleans.Any())
            clean.Id = 0;
        else clean.Id = cleans.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(Clean).GetProperty(prop_name);
            if (prop is null) continue;
            if (model is null) continue;

            LOG($"Property: {prop.Name} Property Type: {prop.PropertyType} Settings to: {prop_val()}");
            if (prop.PropertyType == typeof(string))
                prop.SetValue(clean, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(clean, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int))
                prop.SetValue(clean, Convert.ToInt32(prop_val()), []);
            else if (prop.PropertyType == typeof(double))
                prop.SetValue(clean, Convert.ToDouble(prop_val()), []);
        }

        clean.BookDate = DateTime.Now.ToString();
        
        return clean;
    }
}