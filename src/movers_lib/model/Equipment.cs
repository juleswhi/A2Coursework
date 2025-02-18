namespace Model;

public record Equipment : DatabaseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public int Amount { get; set; }
    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}");
    public Dictionary<string, (Action<DatabaseModel?>, bool)> Buttons()
    {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true) },
            { "Delete", (_ => { }, true) }
        };
    }
}
