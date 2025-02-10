namespace Model;

public class CleaningEquipment : DatabaseModel
{
    public int Id { get; set; }
    public int EquipmentId { get; set; }
    public int[] GetPrimaryKey() => [Id];
}
