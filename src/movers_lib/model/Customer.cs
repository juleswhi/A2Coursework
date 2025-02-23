namespace Model;

public class Customer : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Forename { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public string BillingAddress { get; set; } = String.Empty;
    public string ContactNumber { get; set; } = String.Empty;

    public static Customer GenerateFakeData()
        => new Faker<Customer>()
            .RuleFor(o => o.Id, f => DAL.Query<Customer>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Forename, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .RuleFor(o => o.Address, f => f.Address.StreetAddress())
            .RuleFor(o => o.BillingAddress, f => f.Address.StreetAddress())
            .RuleFor(o => o.ContactNumber, f => f.Phone.PhoneNumber())
            .Generate();
    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => { }, false) },
            { "Edit", (_ => { }, true) },
            { "Delete", (_ => { }, true) }
        };
    }
    public Dictionary<string, (Action<List<(string, Func<string>)>>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => { }, true) },
            { "Delete", (_ => { }, false) }
        };
    }

    public IDatabaseModel CreateFromList(List<(string, Func<string>)> list) {
        throw new NotImplementedException();
    }
}
