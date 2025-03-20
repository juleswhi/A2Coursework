
using View;

namespace Model;

public record StockReorder : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    [ForeignKeyAttribute(typeof(Stock))]
    public int StockId { get; set; }
    public int Quantity { get; set; }
    [DateAttribute]
    [InitialValueDate]
    public string OrderDate { get; set; } = String.Empty;
    [DateAttribute]
    [InitialValueDate]
    public string ExpectedDate { get; set; } = String.Empty;
    public string Status { get; set; } = String.Empty;

    /// <summary>
    /// TODO: UPDATE STOCK TO USE STOCK
    /// </summary>
    /// <returns></returns>
    public static StockReorder GenerateFakeData()
        => new Faker<StockReorder>()
            .RuleFor(o => o.Id, f => DAL.Query<StockReorder>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.StockId, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Quantity, f => f.Random.Number(1_000))
            .RuleFor(o => o.OrderDate, f => f.Date.Past().ToString())
            .RuleFor(o => o.ExpectedDate, f => f.Date.Future().ToString())
            .Generate();

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (new Action<(List<(string, Func<string>)>, IDatabaseModel?)>(list => {
                    //ShowGCFR(typeof(FormCreate), typeof(Clean));

                    var clean = (StockReorder)CreateFromList(list.Item1, list.Item2);

                    clean?.Delete();
                    clean?.Create();

                    // TODO: Maybe go to deliveries page?
                    ShowGCFR(typeof(FormViewModel), typeof(StockReorder));

            }), true) },
        };
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new();
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var clean = new StockReorder();
        var cleans = DAL.Query<StockReorder>();

        if (!cleans.Any())
            clean.Id = 0;
        else clean.Id = cleans.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(StockReorder).GetProperty(prop_name);
            if (prop is null) continue;
            if (model is null) continue;

            LOG($"Property: {prop.Name} Property Type: {prop.PropertyType} Settings to: {prop_val()}");

            if (prop.PropertyType == typeof(string))
                prop.SetValue(clean, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(clean, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int))
                prop.SetValue(clean, Convert.ToInt32(prop_val()), []);
            else if (prop.PropertyType == typeof(double))
                prop.SetValue(clean, Convert.ToDouble(prop_val()), []);
            else if (prop.PropertyType == typeof(DateTime))
                prop.SetValue(clean, Convert.ToDateTime(prop_val()), []);
        }
        
        clean.OrderDate = DateTime.Now.ToString();
        clean.ExpectedDate = DateTime.Now.AddDays(new Random().Next(6, 8)).ToString();

        list.ForEach(x => LOG($"{x.Item1}, {x.Item2()}"));
        LOG($"{model}, MODEL");
        LOG($"{clean}, CLEAN");

        return clean;
    }
}
