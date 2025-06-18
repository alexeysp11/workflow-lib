namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Resolvers;

/// <summary>
/// Memory resolver.
/// </summary>
public static class MemoryResolver
{
    /// <summary>
    /// Collection of the active sessions.
    /// </summary>
    public static Dictionary<string, MenuFormResolver> Sessions { get; private set; }

    private static object _lockObj = new object();

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

    /// <summary>
    /// Get the UID list of inactive sessions.
    /// </summary>
    /// <param name="lastAvailableEditDate">Last available edit date</param>
    /// <returns></returns>
    public static List<string> GetInactiveSessionUidList(DateTime lastAvailableEditDate)
    {
        List<string> sessionsToDelete = Sessions
            .Select(x => x.Value.SessionInfo)
            .Where(x => x != null && x.DateTimeLastUpdated.HasValue && x.DateTimeLastUpdated.Value < lastAvailableEditDate)
            .Select(x => x.SessionUid)
            .ToList();
        return sessionsToDelete;
    }

    /// <summary>
    /// Delete session.
    /// </summary>
    /// <param name="sessionUid">Session UID</param>
    public static void DeleteSession(string sessionUid)
    {
        lock (_lockObj)
        {
            Sessions.Remove(sessionUid);
        }
    }
}