namespace movers_lib.model;

public interface DatabaseModel {
    int[] GetPrimaryKey();
    string FormatPrimaryKey() => GetPrimaryKey().Select(x => x.ToString()).Aggregate((x, y) => $"{x}, {y}");
}
