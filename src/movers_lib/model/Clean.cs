using View;

namespace Model;

public class Clean : DatabaseModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string BookDate { get; set; } = String.Empty;
    public string StartDate { get; set; } = String.Empty;
    public string EndDate { get; set; } = String.Empty;
    public int HoursWorked { get; set; }
    public double Price { get; set; }
    public bool Paid { get; set; }

    public (string, int)[] GetPrimaryKey() => new[] { ("Id", Id) };
    public string FormatWhere() => GetPrimaryKey().Select(x => $"{x.Item1} = '{x.Item2}'").Aggregate((x, y) => $"{x} AND {y}");
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

    public Dictionary<string, (Action<DatabaseModel?>, bool)> Buttons()
    {
        return new() {
            { "Create", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(typeof(Clean)!);
                    // form_meth.Invoke(form, [m]); 
            }, false) },
            { "Edit", (_ => { }, true ) },
            { "Delete", (_ => { }, true) }
        };
    }
}