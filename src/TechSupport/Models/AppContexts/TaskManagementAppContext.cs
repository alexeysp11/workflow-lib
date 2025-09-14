namespace VelocipedeUtils.Examples.TechSupport.Common.Models.AppContexts;

public class TaskManagementAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }
}