using View;

namespace Model;

public record Stock : DatabaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Amount { get; set; }

    private static (string, string)[] productTypes = [
        ("Spade", "Digs Things Up"), ("Pickaxe", "Destroys Things")
        ];

    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}");
    public static Stock GenerateFakeData()
        => new Faker<Stock>()
            .RuleFor(o => o.Id, f => DAL.Query<Stock>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Name, f => f.PickRandom(productTypes.Select(x => x.Item1)))
            .RuleFor(o => o.Description, f => f.PickRandom(productTypes.Select(x => x.Item2)))
            .RuleFor(o => o.Amount, f => f.Random.Number(500))
            .Generate();
    public Dictionary<string, (Action<DatabaseModel?>, bool)> Buttons()
    {
        return new() {
            { "Order Stock", (s => { 
                if(s is null) return;
            }, true) },
            { "Return Stock", (s => {
                if(s is null) return;
            }, true )},
            { "Take Stock", (s => {
                if(s is null) return;
            },true )},
            { "New Stock", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(typeof(Clean)!);
            }, false )}
        };
    }
}
