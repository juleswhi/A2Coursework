namespace Model;

public record Product : DatabaseModel
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
    public static Product GenerateFakeData()
        => new Faker<Product>()
            .RuleFor(o => o.Id, f => DAL.Query<Product>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Name, f => f.PickRandom(productTypes.Select(x => x.Item1)))
            .RuleFor(o => o.Description, f => f.PickRandom(productTypes.Select(x => x.Item2)))
            .RuleFor(o => o.Amount, f => f.Random.Number(500))
            .Generate();
}
