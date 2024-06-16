namespace WorkflowLib.Examples.TechSupport.Common.Models.AppContexts;

public class IncidentsAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }
}