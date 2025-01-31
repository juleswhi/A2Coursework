namespace movers_lib.model;

public class Product : DatabaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Amount { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
