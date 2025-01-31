namespace movers_lib.model;

public class Job : DatabaseModel
{
    public int Id { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
