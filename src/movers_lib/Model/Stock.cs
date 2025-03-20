using View;

namespace Model;

public record Stock : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Amount { get; set; }

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Order Stock", (s => {
                //if(s is null) return;

                ShowGCFR(typeof(FormCreate), typeof(StockReorder));
                var form = Master!.CurrentlyDisplayedForm as FormCreate;
            }, false) },
            { "Return Stock", (s => {
                if(s is null) return;
            }, true )},
            { "Take Stock", (s => {
                if(s is null) return;
            },true )},
            { "New Stock", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Stock));
                    //var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    //var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(typeof(Clean)!);
            }, false )}
        };
    }
    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (list => {
                ShowGCFR(typeof(FormCreate), typeof(Stock));
                var stock = new Stock();
                var stocks = DAL.Query<Stock>();

                if(!stocks.Any())
                    stock.Id = 0;
                else stock.Id = stocks.Select(x => x.Id).Max() + 1;

                foreach(var (prop_name, prop_val) in list.Item1) {
                    var prop = typeof(Stock).GetProperty(prop_name);
                    if(prop is null) continue;

                    if(prop.PropertyType == typeof(string))
                        prop.SetValue(stock, prop_val(), []);
                    else if(prop.PropertyType == typeof(bool))
                        prop.SetValue(stock, Convert.ToBoolean(prop_val()),[]);
                    else if(prop.PropertyType == typeof(int))
                        prop.SetValue(stock, Convert.ToInt32(prop_val()),[]);
                    else if(prop.PropertyType == typeof(double))
                        prop.SetValue(stock, Convert.ToDouble(prop_val()),[]);
                }

                stock.Create();
                ShowGCFR(typeof(FormViewModel), typeof(Stock));
            }, true) },
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        return default;
    }
}
