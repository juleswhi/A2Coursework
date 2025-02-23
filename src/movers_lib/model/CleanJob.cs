
namespace Model;

public class CleanJob : IDatabaseModel {
    [PrimaryKey]
    [ForeignKeyAttribute(typeof(Clean))]
    public int CleanId { get; set; }
    [PrimaryKey]
    [ForeignKeyAttribute(typeof(Employee))]
    public int EmployeeId { get; set; }



    public CleanJob GenerateFakeData()
        => new Faker<CleanJob>()
            .RuleFor(o => o.CleanId, f => f.PickRandom(DAL.Query<Clean>().Select(o => o.Id)))
            .RuleFor(o => o.EmployeeId, f => f.PickRandom(DAL.Query<Employee>().Select(x => x.Id)))
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
