namespace movers_lib.model;

public class CleanJob : DatabaseModel
{
    public int CleanId { get; set; }
    public int EmployeeId { get; set; }
    public int[] GetPrimaryKey() => [CleanId, EmployeeId];
}
