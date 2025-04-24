namespace WorkflowLib.PixelTerminalUI.ServiceEngine.Controls;

/// <summary>
/// Field for selecting from a list.
/// </summary>
public class ComboEditControl : TextEditControl
{
    /// <summary>
    /// Determines whether to open a separate form for selection.
    /// </summary>
    public bool ShowOnlyFormInput { get; set; }

    /// <summary>
    /// Show additional information about options to select.
    /// </summary>
    public bool ShowItemsAdditionalInfo { get; set; }

    /// <summary>
    /// Determines whether two or more items can be selected from the provided list.
    /// </summary>
    public bool MultiSelectEnabled { get; set; }
}
