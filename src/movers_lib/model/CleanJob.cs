namespace Model;

public class CleanJob : DatabaseModel
{
    public int CleanId { get; set; }
    public int EmployeeId { get; set; }
    public (string, int)[] GetPrimaryKey() => [(nameof(CleanId), CleanId), (nameof(EmployeeId), EmployeeId)];
    public string FormatWhere() => GetPrimaryKey().Select(x => $"{x.Item1} = '{x.Item2}'").Aggregate((x, y) => $"{x} AND {y}"); 
    public CleanJob GenerateFakeData()
        => new Faker<CleanJob>()
            .RuleFor(o => o.CleanId, f => f.PickRandom(DAL.Query<Clean>().Select(o => o.Id)))
            .RuleFor(o => o.EmployeeId, f => f.PickRandom(DAL.Query<Employee>().Select(x => x.Id)))
            .Generate();
}
