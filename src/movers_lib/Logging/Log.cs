using System.Diagnostics;

namespace movers_lib.logging;

public static class Logger
{
    public static void ASSERT(bool condition)
    {
        Debug.Assert(condition);
    }
    public static void LOG(string s)
    {
        Debug.Print(s);
    }
}
