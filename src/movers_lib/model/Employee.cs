namespace Model;

public record Employee : DatabaseModel
{
    public int Id { get; set; }
    public string Forename { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public int JobId { get; set; }
    public int TeamId { get; set; }
    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}");
    public static Employee GenerateFakeData()
        => new Faker<Employee>()
            .RuleFor(o => o.Id, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Forename, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .RuleFor(o => o.JobId, f => f.PickRandom(DAL.Query<Job>().Select(x => x.Id)))
            .RuleFor(o => o.TeamId, f => f.PickRandom(DAL.Query<Team>().Select(x => x.Id)))
            .Generate();
    public Dictionary<string, Action<DatabaseModel>> Buttons()
    {
        return new() {
            { "Create", _ => { } },
            { "Edit", _ => { } },
            { "Delete", _ => { } }
        };
    }
}
