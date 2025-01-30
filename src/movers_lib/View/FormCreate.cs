using movers_lib.model;

namespace movers_lib.View;

public partial class FormCreate : Form, GenericCreateableForm
{
    public FormCreate()
    {
        InitializeComponent();
    }

    public void Create<T>() where T : DatabaseModel
    {

    }
}
