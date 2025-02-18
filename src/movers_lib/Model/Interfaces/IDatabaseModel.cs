namespace Model;

public interface IDatabaseModel {
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons();
    public Dictionary<string, (Action<List<string>?>, bool)> CreateButtons();
}
