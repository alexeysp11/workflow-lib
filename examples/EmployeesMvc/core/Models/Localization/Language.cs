using System.Collections.Generic;

namespace WorkflowLib.Examples.EmployeesMvc.Core.Models.Localization;

/// <summary>
/// Language.
/// </summary>
public class Language
{
    /// <summary>
    /// Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Elements.
    /// </summary>
    public List<LanguageElement> Elements { get; set; }
}