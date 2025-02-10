namespace Model;

public class StockReorder : DatabaseModel
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ReceivedDate { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
