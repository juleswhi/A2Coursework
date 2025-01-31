namespace movers_lib.model;

public class Clean : DatabaseModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int HoursWorked { get; set; }
    public double Price { get; set; }
    public bool Paid { get; set; }

    public int[] GetPrimaryKey() => [Id];
}
