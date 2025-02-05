namespace database;

public static class DalHelper
{
    public static object? InvokeQueryGeneric(Type t) => 
        typeof(DAL).
        GetMethod(nameof(DAL.Query))!.
        MakeGenericMethod(t).
        Invoke(null, null);
    public static object? InvokeGenericMethodCall(Type t1, string method_name, Type t2) =>
        t1.GetMethod(method_name)!.
        MakeGenericMethod(t2).
        Invoke(null, null);
    public static object? InvokeGenericMethodCall(Type t1, string method_name, Type t2, params object[] parameters) =>
        t1.GetMethod(method_name)!.
        MakeGenericMethod(t2).
        Invoke(null, parameters);
}
