namespace Model;

public interface IDatabaseModel {
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons();
    // The list is a tuple type where the Item1 = PropertyName and Item2 = property value
    public Dictionary<string, (Action<List<(string, Func<string>)>>, bool)> CreateButtons();
}
