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
                ShowGCFR(typeof(FormCreate), typeof(StockReorder));
                var form = Master!.CurrentlyDisplayedForm as FormCreate;

                form?.Populate(new StockReorder() {
                    StockId = (s as Stock)!.Id
                });

            }, false) },

            { "Take Stock", (s => {
                if(s is null) return;

                ShowGCFR(typeof(FormCreate), typeof(TakeStock));
                var form  = Master!.CurrentlyDisplayedForm as FormCreate;

                form?.Populate(new TakeStock() {
                    StockId = (s as Stock)!.Id
                });
            },true )},
            { "Return Stock", (new Action<IDatabaseModel?>(s => {
                if(s is null) return;

                ShowGCF<FormSelectViewModel, TakeStock>();

                var formSelectViewModel = ((Master as FormSkeleton)!.CurrentForm as FormSelectViewModel)!;

                var action = (int takestock_id) => {
                    var takestock = DAL.Query<TakeStock>().First(x => x.Id == takestock_id);

                    DAL.Delete(takestock);
                    var stock = DAL.Query<Stock>().First(x => x.Id == takestock.StockId);
                    stock.Amount += takestock.Amount;
                    stock.Update();

                    ShowGCF<FormViewModel, Stock>();
                };

                typeof(FormSelectViewModel).
                    GetMethod(nameof(FormSelectViewModel.SetCallbackReturnKey))!.
                    Invoke(formSelectViewModel, [action]);

            }), true )},
            { "New Stock", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Stock));
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
                //ShowForm<FormDeliveries>();
            }, true) },
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        return default;
    }
}
