using movers_lib.model;

namespace movers_lib.View;

public interface GenericCreateableForm
{
    public void Create<T>() where T : DatabaseModel;
}
