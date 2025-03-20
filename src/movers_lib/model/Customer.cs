
using View;

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

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (new Action<(List<(string, Func<string>)>, IDatabaseModel?)>(list => {
                    var customer = (Customer)CreateFromList(list.Item1, list.Item2)!;

                    customer.Delete();
                    customer.Create();

                    ShowGCFR(typeof(FormViewModel), typeof(Customer));
            }), true) },
        };
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Customer));
            }, false) },
            { "Edit", (m => {
                    ShowGCFR(typeof(FormCreate), typeof(Customer));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().
                    GetMethod(nameof(form.Populate))!.
                    MakeGenericMethod(typeof(Customer)!);
                    form_meth.Invoke(form, [m]);
            }, true) },
            { "Delete", (m => {
                    DAL.Delete((Customer)m!);
                    ShowGCF<FormViewModel, Customer>();
            }, true) }
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var customer = new Customer();
        var customers = DAL.Query<Customer>();

        if (!customers.Any())
            customer.Id = 0;
        else customer.Id = customers.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(Customer).GetProperty(prop_name);
            if (prop is null) continue;
            // if (model is null) continue;

            LOG($"Property: {prop.Name} Property Type: {prop.PropertyType} Settings to: {prop_val()}");

            if (prop.PropertyType == typeof(string))
                prop.SetValue(customer, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(customer, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int))
                prop.SetValue(customer, Convert.ToInt32(prop_val()), []);
            else if (prop.PropertyType == typeof(double))
                prop.SetValue(customer, Convert.ToDouble(prop_val()), []);
            else if (prop.PropertyType == typeof(DateTime))
                prop.SetValue(customer, Convert.ToDateTime(prop_val()), []);
        }
        
        // customer.OrderDate = DateTime.Now.ToString();
        //customer.ExpectedDate = DateTime.Now.AddDays(new Random().Next(6, 8)).ToString();

        list.ForEach(x => LOG($"{x.Item1}, {x.Item2()}"));
        LOG($"{(model as Customer)?.Id}, MODEL ID");
        LOG($"{customer.Id}, customer ID");

        if(model is not null) {
            customer.Id = (model as Customer)!.Id;
        }

        return customer;
    }
}
