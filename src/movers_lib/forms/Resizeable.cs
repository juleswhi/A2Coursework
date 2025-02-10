namespace Forms;

public interface IResizeable
{
    void OnViewPortChanged();
}

public interface IResizeableControl
{
    void OnViewPortChanged(Size new_size);
}
