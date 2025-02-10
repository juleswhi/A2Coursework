namespace Model;

public class Customer : DatabaseModel
{
    public int Id { get; set; }
    public string Forename { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Address { get; set; } = "";
    public string BillingAddress { get; set; } = "";
    public string ContactNumber { get; set; } = "";
    public int[] GetPrimaryKey() => [Id];
}
