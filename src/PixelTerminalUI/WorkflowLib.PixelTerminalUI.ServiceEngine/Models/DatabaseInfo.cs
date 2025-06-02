namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

/// <summary>
/// Information about databases.
/// </summary>
public class DatabaseInfo
{
    /// <summary>
    /// Displayed index of the database in combo.
    /// </summary>
    public int Index { get; set; }

    /// <summary>
    /// Name of the database.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Description of the database.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Connection string.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>
    /// Determines whether connection needs to be established.
    /// </summary>
    public bool? NeedConnection { get; set; } = true;
}