using View;

namespace Model;

public class Clean : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKey(typeof(Customer))]
    public int CustomerId { get; set; }
    public string BookDate { get; set; } = String.Empty;
    public string StartDate { get; set; } = String.Empty;
    public string EndDate { get; set; } = String.Empty;
    public int HoursWorked { get; set; }
    public double Price { get; set; }
    public bool Paid { get; set; }

    public static Clean GenerateFakeData()
        => new Faker<Clean>()
            .RuleFor(o => o.Id, f => DAL.Query<Clean>().Select(o => o.Id).Max() + 1)
            .RuleFor(o => o.CustomerId, f => f.PickRandom(DAL.Query<Customer>().Select(x => x.Id)))
            .RuleFor(o => o.BookDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.StartDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.EndDate, f => f.Date.Future().ToString())
            .RuleFor(o => o.HoursWorked, f => f.Random.Number(0, 50))
            .RuleFor(o => o.Price, f => f.Random.Number(0, 10_000))
            .RuleFor(o => o.Paid, f => f.Random.Bool())
            .Generate();

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(typeof(Clean)!);
                    // form_meth.Invoke(form, [m]); 
            }, false) },
            { "Peter", (_ => { }, true ) },
            { "Delete", (_ => { }, true) }
        };
    }
    public Dictionary<string, (Action<List<string>?>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => {

            }, true) },
            { "Back", (_ => ShowGCFR(typeof(FormViewModel), typeof(Clean)), false) }
        };
    }
}