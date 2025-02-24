
namespace Model;

public record StockReorder : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKeyAttribute(typeof(Stock))]
    public int StockId { get; set; }
    public int Quantity { get; set; }
    [DateAttribute]
    public string OrderDate { get; set; } = String.Empty;
    [DateAttribute]
    public string ExpectedDate { get; set; } = String.Empty;
    public string Status { get; set; } = String.Empty;

    /// <summary>
    /// TODO: UPDATE STOCK TO USE STOCK
    /// </summary>
    /// <returns></returns>
    public static StockReorder GenerateFakeData()
        => new Faker<StockReorder>()
            .RuleFor(o => o.Id, f => DAL.Query<StockReorder>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.StockId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Quantity, f => f.Random.Number(1_000))
            .RuleFor(o => o.OrderDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.ExpectedDate, f => f.Date.Future().ToString())
            .Generate();

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new();
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new();
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        return default;
    }
}
