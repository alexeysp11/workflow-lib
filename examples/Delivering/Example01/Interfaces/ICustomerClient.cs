using WorkflowLib.Models.Business.Monetary;
using WorkflowLib.Models.Business.BusinessDocuments;

namespace WorkflowLib.Examples.Delivering.Example01.Interfaces
{
    public interface ICustomerClient
    {
        string MakeOrder(InitialOrder model);
        string MakePayment(object input);
    }
}