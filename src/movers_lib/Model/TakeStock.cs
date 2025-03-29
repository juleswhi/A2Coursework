using View;

namespace Model;
public class TakeStock : IDatabaseModel {

    [PrimaryKey]
    public int Id { get; set; }

    [ForeignKeyAttribute(typeof(Stock))]
    public int StockId { get; set; }

    public int Amount { get; set; }


    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (new Action<(List<(string, Func<string>)>, IDatabaseModel?)>(list => {
                    var take_stock = (TakeStock)CreateFromList(list.Item1, list.Item2)!;

                    take_stock.Delete();
                    take_stock.Create();

                    var stock = DAL.Query<Stock>().First(x => x.Id == take_stock.StockId);
                    stock.Amount -= take_stock.Amount;

                    stock.Update();

                    ShowGCFR(typeof(FormViewModel), typeof(Stock));
            }), true) },
        };
    }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() { };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var takestock = new TakeStock();
        var takestocks = DAL.Query<TakeStock>();

        if (!takestocks.Any())
            takestock.Id = 0;
        else takestock.Id = takestocks.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(TakeStock).GetProperty(prop_name);
            if (prop is null || prop_val() == "") continue;

            if (prop.PropertyType == typeof(string))
                prop.SetValue(takestock, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(takestock, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int)) {
                if (prop_val() == "Choose") {
                    prop.SetValue(takestock, 0, []);
                    continue;
                }
                prop.SetValue(takestock, Convert.ToInt32(prop_val()), []);
            } else if (prop.PropertyType == typeof(double))
                prop.SetValue(takestock, Convert.ToDouble(prop_val()), []);
            else if (prop.PropertyType == typeof(DateTime))
                prop.SetValue(takestock, Convert.ToDateTime(prop_val()), []);
        }

        //if (model is TakeStock ts) {
        //    takestock.Id = ts.Id;
        //}

        return takestock;
    }
}
