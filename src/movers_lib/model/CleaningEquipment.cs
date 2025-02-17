namespace Model;

public record CleaningEquipment : DatabaseModel
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public (string, int)[] GetPrimaryKey() => [("Id", Id)];
    public string FormatWhere() => GetPrimaryKey().Select(x => $"{x.Item1} = '{x.Item2}'").Aggregate((x, y) => $"{x} AND {y}");
    public CleaningEquipment GenerateFakeData()
        => new Faker<CleaningEquipment>()
            .RuleFor(o => o.Id, f => DAL.Query<CleaningEquipment>().Select(o => o.Id).Max() + 1)
            .RuleFor(o => o.EquipmentId, f => f.PickRandom(DAL.Query<Equipment>().Select(x => x.Id)))
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
