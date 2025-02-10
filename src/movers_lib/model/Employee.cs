namespace Model;

public class Employee : DatabaseModel
{
    public int Id { get; set; }
    public string Forename { get; set; } = "";
    public string Surname { get; set; } = "";
    public int JobId { get; set; } 
    public int TeamId { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
