
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
    [InitialValueString("Processing")]
    public string Status { get; set; } = String.Empty;

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
                    var clean = (StockReorder)CreateFromList(list.Item1, list.Item2)!;

                    clean?.Delete();
                    clean?.Create();

                    ShowGCFR(typeof(FormViewModel), typeof(StockReorder));

            }), true) },
        };
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new();
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var stock_reorder = new StockReorder();
        var reorders = DAL.Query<StockReorder>();

        if (!reorders.Any())
            stock_reorder.Id = 0;
        else stock_reorder.Id = reorders.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(StockReorder).GetProperty(prop_name);
            if (prop is null || prop_val() == "") continue;

            LOG($"Property: {prop.Name} Property Type: {prop.PropertyType} Settings to: {prop_val()}");

            if (prop.PropertyType == typeof(string))
                prop.SetValue(stock_reorder, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(stock_reorder, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int)) {
                if (prop_val() == "Choose") {
                    prop.SetValue(stock_reorder, 0, []);
                    continue;
                }
                prop.SetValue(stock_reorder, Convert.ToInt32(prop_val()), []);
            } else if (prop.PropertyType == typeof(double))
                prop.SetValue(stock_reorder, Convert.ToDouble(prop_val()), []);
        }

        stock_reorder.OrderDate = DateTime.Now.ToString();
        stock_reorder.ExpectedDate = DateTime.Now.AddDays(new Random().Next(6, 8)).ToString();
        stock_reorder.Status = "Processing";

        return stock_reorder;
    }
}
