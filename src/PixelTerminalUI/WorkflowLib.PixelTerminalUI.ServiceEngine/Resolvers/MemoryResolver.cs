namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

/// <summary>
/// Memory resolver.
/// </summary>
public static class MemoryResolver
{
    private static Dictionary<string, MenuFormResolver> Sessions { get; set; }

    static MemoryResolver()
    {
        Sessions = new Dictionary<string, MenuFormResolver>();
    }

    /// <summary>
    /// Save the instance of <see cref="MenuFormResolver"/>.
    /// </summary>
    /// <param name="sessionUid">Session UID</param>
    /// <param name="menuFormResolver">New instance of <see cref="MenuFormResolver"/></param>
    /// <param name="addWithoutCheck">Determines whether the instance is supposed to be added without check</param>
    public static void SaveMenuFormResolver(
        string sessionUid,
        MenuFormResolver menuFormResolver,
        bool addWithoutCheck)
    {
        if (menuFormResolver == null)
        {
            throw new ArgumentNullException(nameof(menuFormResolver), $"The instance of {nameof(MenuFormResolver)} could not be null");
        }

        if (addWithoutCheck || GetMenuFormResolver(sessionUid) == null)
        {
            Sessions.Add(sessionUid, menuFormResolver);
        }
        else
        {
            Sessions[sessionUid] = menuFormResolver;
        }
    }

    /// <summary>
    /// Get the instance of <see cref="MenuFormResolver"/>.
    /// </summary>
    /// <param name="sessionUid">Session UID</param>
    /// <returns></returns>
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