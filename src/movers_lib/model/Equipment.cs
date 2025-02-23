
namespace Model;

public record Equipment : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Description { get; set; } = String.Empty;
    public int Amount { get; set; }

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
