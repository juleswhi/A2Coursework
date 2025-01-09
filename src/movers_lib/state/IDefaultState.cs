namespace state;

public interface IDefaultState : IState
{
    public new void State(State state) { }
}
