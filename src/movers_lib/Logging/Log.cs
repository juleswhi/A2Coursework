using System.Diagnostics;

namespace Logging;

public static class Logger {
    public static void ASSERT(bool condition) {
        Debug.Assert(condition);
    }

    public static void LOG(string s) {
        Debug.Print(s);
    }
}
