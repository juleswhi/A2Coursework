namespace Model;

public record Team : DatabaseModel
{
    public int Id { get; set; }
    public double HourlyRate { get; set; }
    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}"); 
    public static Team GenerateFakeData()
        => new Faker<Team>()
            .RuleFor(o => o.Id, f => DAL.Query<Team>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.HourlyRate, f => f.Random.Number(50))
            .Generate();
}
