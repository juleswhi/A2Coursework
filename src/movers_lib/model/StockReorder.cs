namespace Model;

public record StockReorder : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKey(typeof(Employee))]
    public int EmployeeId { get; set; }
    [ForeignKey(typeof(Stock))]
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public string OrderDate { get; set; } = String.Empty;
    public string ReceivedDate { get; set; } = String.Empty;

    /// <summary>
    /// TODO: UPDATE STOCK TO USE STOCK
    /// </summary>
    /// <returns></returns>
    public static StockReorder GenerateFakeData()
        => new Faker<StockReorder>()
            .RuleFor(o => o.Id, f => DAL.Query<StockReorder>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.EmployeeId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.StockId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Quantity, f => f.Random.Number(1_000))
            .RuleFor(o => o.OrderDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.ReceivedDate, f => f.Date.Future().ToString())
            .Generate();
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true) },
            { "Delete", (_ => { }, true) }
        };
    }
    public Dictionary<string, (Action<List<string>?>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => { }, true) },
            { "Delete", (_ => { }, false) }
        };
    }
}
