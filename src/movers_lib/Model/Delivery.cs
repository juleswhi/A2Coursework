namespace Model;
public class Delivery : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKeyAttribute(typeof(Stock))]
    public int StockId { get; set; }
    public int Amount { get; set; }
    public string DeliveryDate { get; set; } = String.Empty;
    [InitialValueBool(false)]
    public bool Received { get; set; }

    public Dictionary<string, (Action<List<(string, Func<string>)>>, bool)> CreateButtons() => new();

    public IDatabaseModel CreateFromList(List<(string, Func<string>)> list) {
        throw new NotImplementedException();
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() => new();
}
