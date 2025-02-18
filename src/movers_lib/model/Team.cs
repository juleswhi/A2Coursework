namespace Model;

public record Team : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public double HourlyRate { get; set; }

    public static Team GenerateFakeData()
        => new Faker<Team>()
            .RuleFor(o => o.Id, f => DAL.Query<Team>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.HourlyRate, f => f.Random.Number(50))
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
