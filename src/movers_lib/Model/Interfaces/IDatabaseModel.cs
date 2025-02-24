namespace Model;

public interface IDatabaseModel {
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons();
    // The list is a tuple type where the Item1 = PropertyName and Item2 = property value
    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons();
    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model);
}
