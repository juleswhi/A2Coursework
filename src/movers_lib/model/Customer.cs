namespace Model;

public class Customer : DatabaseModel
{
    public int Id { get; set; }
    public string Forename { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public string BillingAddress { get; set; } = String.Empty;
    public string ContactNumber { get; set; } = String.Empty;

    public (string, int)[] GetPrimaryKey() => [(nameof(Id), Id)];
    public string FormatWhere() => GetPrimaryKey().Select(x => $"{x.Item1} = '{x.Item2}'").Aggregate((x, y) => $"{x} AND {y}"); 
    public static Customer GenerateFakeData()
        => new Faker<Customer>()
            .RuleFor(o => o.Id, f => DAL.Query<Customer>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Forename, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.BillingAddress, f => f.Address.StreetAddress())
            .RuleFor(o => o.ContactNumber, f => f.Phone.PhoneNumber())
            .Generate();
}
