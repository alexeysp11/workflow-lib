using WorkflowLib.Examples.TechSupport.Common.Models;

namespace WorkflowLib.Examples.TechSupport.Common.Models.AppContexts;

public class CustomersAppContext : IAppContext
{
    public AuthenticationContext AuthenticationContext { get; set; }
    public UserContext UserContext { get; set; }
    public ApplicationContext ApplicationContext { get; set; }

    public Customer CurrentCustomer { get; set; }
}