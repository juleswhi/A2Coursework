
namespace Model;

public record Job : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }

    public static Job GenerateFakeData()
        => new Faker<Job>()
            .RuleFor(o => o.Id, f => DAL.Query<Job>().Select(x => x.Id).Max() + 1)
            .Generate();

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new();
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new();
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>, IDatabaseModel?)> list) {
        return default;
    }
}
