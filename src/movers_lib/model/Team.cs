namespace Model;

public class Team : DatabaseModel
{
    public int Id { get; set; }
    public double HourlyRate { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
