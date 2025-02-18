namespace Model;

public record StockReorder : DatabaseModel
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string OrderDate { get; set; } = String.Empty;
    public string ReceivedDate { get; set; } = String.Empty;
    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}");
    public static StockReorder GenerateFakeData()
        => new Faker<StockReorder>()
            .RuleFor(o => o.Id, f => DAL.Query<StockReorder>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.EmployeeId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.ProductId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Quantity, f => f.Random.Number(1_000))
            .RuleFor(o => o.OrderDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.ReceivedDate, f => f.Date.Future().ToString())
            .Generate();
    public Dictionary<string, (Action<DatabaseModel?>, bool)> Buttons()
    {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true) },
            { "Delete", (_ => { }, true) }
        };
    }
}
