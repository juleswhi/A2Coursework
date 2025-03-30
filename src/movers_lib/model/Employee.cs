using View;
namespace Model;

public record Employee : IDatabaseModel {
    [PrimaryKey]
    public int Id { get; set; }
    public string Forename { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;

    public static Employee GenerateFakeData()
        => new Faker<Employee>()
            .RuleFor(o => o.Id, f => DAL.Query<Employee>().Select(x => x.Id).Max() + 1)
            .RuleFor(o => o.Forename, f => f.Name.FirstName())
            .RuleFor(o => o.Surname, f => f.Name.LastName())
            .Generate();

    public Dictionary<string, (Action<IDatabaseModel?>, bool)> ViewButtons() {
        return new() {
            { "Create", (new Action<IDatabaseModel?>(list => {
                    ShowGCFR(typeof(FormCreate), typeof(Employee));
            }), false) },
            { "Edit", (m => {
                    ShowGCFR(typeof(FormCreate), typeof(Employee));
                    var form = Master!.CurrentlyDisplayedForm as FormCreate;
                    var form_meth = form!.GetType().
                    GetMethod(nameof(form.Populate))!.
                    MakeGenericMethod(typeof(Employee)!);
                    form_meth.Invoke(form, [m]);
            }, true) },
            { "Assign To Job", (new Action<IDatabaseModel?>(m => {

                ShowGCF<FormSelectViewModel, Clean>();
                var cleanJob = new CleanJob();

                var formSelectViewModel = ((Master as FormSkeleton)!.CurrentForm as FormSelectViewModel)!;

                var action = (int clean_id) => {
                    cleanJob.CleanId = clean_id;
                    cleanJob.EmployeeId = (m as Employee)!.Id;

                    if(DAL.Query<CleanJob>().Any(x => x.CleanId == clean_id && x.EmployeeId == cleanJob.EmployeeId)) {
                        ShowGCF<FormViewModel, Employee>();
                        return;
                    }

                    DAL.Create(cleanJob);
                    ShowGCF<FormViewModel, Employee>();
                };

                typeof(FormSelectViewModel).
                    GetMethod(nameof(FormSelectViewModel.SetCallbackReturnKey))!.
                    Invoke(formSelectViewModel, [action]);

            }), true) },
            { "Delete", (m => {
                DAL.Delete((Employee)m!);
                ShowGCF<FormViewModel, Employee>();
            }, true) }
        };
    }

    public Dictionary<string, (Action<(List<(string, Func<string>)>, IDatabaseModel?)>, bool)> CreateButtons() {
        return new() {
            { "Create", (list => {
                    var employee = (Employee)CreateFromList(list.Item1, list.Item2)!;

                    employee.Delete();
                    employee.Create();

                    ShowGCFR(typeof(FormViewModel), typeof(Employee));
            }, true) },
        };
    }

    public IDatabaseModel? CreateFromList(List<(string, Func<string>)> list, IDatabaseModel? model) {
        var employee = new Employee();
        var employees = DAL.Query<Employee>();

        if (!employees.Any())
            employee.Id = 0;
        else employee.Id = employees.Select(x => x.Id).Max() + 1;

        foreach (var (prop_name, prop_val) in list) {
            var prop = typeof(Employee).GetProperty(prop_name);
            if (prop is null || prop_val() == "") continue;

            if (prop.PropertyType == typeof(string))
                prop.SetValue(employee, prop_val(), []);
            else if (prop.PropertyType == typeof(bool))
                prop.SetValue(employee, Convert.ToBoolean(prop_val()), []);
            else if (prop.PropertyType == typeof(int)) {
                if (prop_val() == "Choose") {
                    prop.SetValue(employee, 0, []);
                    continue;
                }
                prop.SetValue(employee, Convert.ToInt32(prop_val()), []);
            } else if (prop.PropertyType == typeof(double))
                prop.SetValue(employee, Convert.ToDouble(prop_val()), []);
            else if (prop.PropertyType == typeof(DateTime))
                prop.SetValue(employee, Convert.ToDateTime(prop_val()), []);
        }

        if (model is Employee e) {
            employee.Id = e.Id;
        }

        return employee;
    }
}
