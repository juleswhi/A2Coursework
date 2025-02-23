namespace Model;

public record Equipment : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public int Amount { get; set; }
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true) },
            { "Delete", (_ => { }, true) }
        };
    }
    public Dictionary<string, (Action<List<(string, Func<string>)>>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => { }, true) },
            { "Delete", (_ => { }, false) }
        };
    }

    public IDatabaseModel CreateFromList(List<(string, Func<string>)> list) {
        throw new NotImplementedException();
    }
}
