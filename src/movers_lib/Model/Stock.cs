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
                if(s is null) return;
            }, true) },
            { "Return Stock", (s => {
                if(s is null) return;
            }, true )},
            { "Take Stock", (s => {
                if(s is null) return;
            },true )},
            { "New Stock", (_ => {
                    ShowGCFR(typeof(FormCreate), typeof(Clean));
                    //var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    //var form_meth = form!.GetType().GetMethod(nameof(form.Populate))!.MakeGenericMethod(typeof(Clean)!);
            }, false )}
        };
    }
    public Dictionary<string, (Action<List<string>?>, bool)> CreateButtons() {
        return new() {
            { "Create", (_ => { }, true) },
            { "Delete", (_ => { }, false) }
        };
    }
}
