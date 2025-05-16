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
        // - createdb.sql
        // - initdata.sql
        // - EF Core migrations
        // - OrganizationItemsFunctions.sql
        // - useraccounts.sql
        // - absenses.sql
        // - languages.sql
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