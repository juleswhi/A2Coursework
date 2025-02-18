namespace Model;

public record Employee : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Forename { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    [ForeignKey(typeof(Job))]
    public int JobId { get; set; }
    [ForeignKey(typeof(Team))]
    public int TeamId { get; set; }
    public static Employee GenerateFakeData()
        => new Faker<Employee>()
            .RuleFor(o => o.Id, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Forename, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .RuleFor(o => o.JobId, f => f.PickRandom(DAL.Query<Job>().Select(x => x.Id)))
            .RuleFor(o => o.TeamId, f => f.PickRandom(DAL.Query<Team>().Select(x => x.Id)))
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
