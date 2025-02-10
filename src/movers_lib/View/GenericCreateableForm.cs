using Model;

namespace View;

public interface GenericCreateableForm
{
    public void Create<T>() where T : DatabaseModel;
}
