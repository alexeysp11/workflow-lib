namespace VelocipedeUtils.Examples.TechSupport.Common.Models.AppContexts;

/// <summary>
/// Хранит данные, специфичные для данного приложения, такие как текущая страница, активная вкладка и любые другие данные, 
/// которые необходимо сохранить при переключении между приложениями.
/// </summary>
public class ApplicationContext
{
    public string CurrentPage { get; set; }
    public string ActiveTab { get; set; }
    public Dictionary<string, object> Data { get; set; }
}