using VelocipedeUtils.Examples.TechSupport.Common.Models;

namespace VelocipedeUtils.Examples.TechSupport.Common.Models.AppContexts;

public class EventJournalAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public Event CurrentEvent { get; set; }
}