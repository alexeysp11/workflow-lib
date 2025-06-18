namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Models;

/// <summary>
/// Application settings.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Initial form type name.
    /// </summary>
    public string? InitialFormTypeName { get; set; }

    /// <summary>
    /// Menu code.
    /// </summary>
    public string? MenuCode { get; set; }

    /// <summary>
    /// he maximum amount of minutes a session could be active.
    /// </summary>
    public int? MaxMinutesActiveSession { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int? SessionCheckPeriodQty { get; set; }

    /// <summary>
    /// List of the database info.
    /// </summary>
    public List<DatabaseInfo>? DatabaseInfoList { get; set; }
}