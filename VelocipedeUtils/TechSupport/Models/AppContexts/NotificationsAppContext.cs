namespace VelocipedeUtils.Examples.TechSupport.Common.Models.AppContexts;

public class NotificationsAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public int UnreadNotificationsCount { get; set; }
}