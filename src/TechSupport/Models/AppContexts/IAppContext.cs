namespace WorkflowLib.Examples.TechSupport.Common.Models.AppContexts;

public interface IAppContext
{
    AuthenticationContext AuthenticationContext { get; set; }
    UserContext UserContext { get; set; }
    ApplicationContext ApplicationContext { get; set; }
}