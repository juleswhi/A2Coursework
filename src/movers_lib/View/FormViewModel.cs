using database;
using movers_lib.model;

namespace movers_lib.View;

public partial class FormViewModel : Form
{
    public FormViewModel()
    {
        InitializeComponent();

        var customers = DAL.Query<Customer>([]);

        dataGridView.DataSource = customers;
    }
    
}