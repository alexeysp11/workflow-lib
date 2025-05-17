namespace WorkflowLib.UnifiedBusinessPlatform.DbInit;

/// <summary>
/// Class for standardized launch of an application instance.
/// </summary>
public class StartupInstance : IStartupInstance
{
    /// <summary>
    /// Method for standardized launch of an application instance.
    /// </summary>
    public void Start()
    {
        Console.WriteLine("Initializing the database...");

        // Sequence of the actions:
        // - CreateDb.sql
        // - InitData.sql
        // - EF Core migrations
        // - OrganizationItemsFunctions.sql
        // - UserAccounts.sql
        // - Absenses.sql
        // - Languages.sql
    }

    private void CheckActionsDefinitions()
    {
        // 
    }

    private void ExecuteSqlFromFile(string filepath)
    {
        // 
    }
}