namespace Model;
public class Delivery : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKey(typeof(Stock))]
    public int StockId { get; set; }
    public int Amount { get; set; }
    public string DeliveryDate { get; set; } = String.Empty;

    public Dictionary<string, (Action<List<(string, Func<string>)>>, bool)> CreateButtons() => new();
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() => new();
}
