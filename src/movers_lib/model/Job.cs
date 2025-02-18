namespace Model;

public record Job : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public static Job GenerateFakeData()
        => new Faker<Job>()
            .RuleFor(o => o.Id, f => DAL.Query<Job>().Select(x => x.Id).Max() + 1)
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
