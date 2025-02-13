namespace Model;

public record Job : DatabaseModel
{
    public int Id { get; set; }
    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}"); 
    public static Job GenerateFakeData()
        => new Faker<Job>()
            .RuleFor(o => o.Id, f => DAL.Query<Job>().Select(x => x.Id).Max() + 1)
            .Generate();
}
