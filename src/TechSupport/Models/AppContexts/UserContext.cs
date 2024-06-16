namespace WorkflowLib.Examples.TechSupport.Common.Models.AppContexts;

/// <summary>
/// Содержит данные о пользователе, такие как его имя, адрес электронной почты и настройки.
/// </summary>
public class UserContext
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> Settings { get; set; }
}