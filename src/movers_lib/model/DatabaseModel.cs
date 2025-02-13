using MaterialSkin;

namespace Model;

public interface DatabaseModel {
    public (string, int)[] GetPrimaryKey();
    public string FormatWhere() => GetPrimaryKey().Select((x, y) => $"{x} = '{y}'").Aggregate((x, y) => $"{x} AND {y}"); 
}
