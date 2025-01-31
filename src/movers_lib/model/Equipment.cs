namespace movers_lib.model;

public class Equipment : DatabaseModel
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public int Amount { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
