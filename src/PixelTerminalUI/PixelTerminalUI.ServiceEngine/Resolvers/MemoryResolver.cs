namespace PixelTerminalUI.ServiceEngine.Resolvers;

public static class MemoryResolver
{
    private static Dictionary<string, MenuFormResolver> Sessions { get; set; }

    static MemoryResolver()
    {
        Sessions = new Dictionary<string, MenuFormResolver>();
    }

    public static void SaveMenuFormResolver(string sessionUid, MenuFormResolver menuFormResolver)
    {
        Sessions.Add(sessionUid, menuFormResolver);
    }

    public static MenuFormResolver? GetMenuFormResolver(string sessionUid)
    {
        MenuFormResolver? menuFormResolver = null;
        if (Sessions.TryGetValue(sessionUid, out MenuFormResolver value))
        {
            menuFormResolver = value;
        }
        return menuFormResolver;
    }
}