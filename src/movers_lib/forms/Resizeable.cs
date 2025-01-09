namespace movers_lib.forms;

public interface IResizeable
{
    void OnViewPortChanged();
}

public interface IResizeableControl
{
    void OnViewPortChanged(Size new_size);
}
