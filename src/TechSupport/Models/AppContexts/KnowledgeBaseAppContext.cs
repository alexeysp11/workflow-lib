namespace WorkflowLib.Examples.TechSupport.Common.Models.AppContexts;

public class KnowledgeBaseAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }
}