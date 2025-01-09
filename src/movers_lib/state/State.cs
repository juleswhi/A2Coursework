namespace state;

public class State : Dictionary<IEnumerable<StateType>, object?>
{
    public static State From()
    {
        return GetGlobalState();
    }
}
