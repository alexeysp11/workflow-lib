using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;

namespace Cims.WorkflowLib.Example01.Interfaces
{
    public interface ICustomerClient
    {
        string MakeOrder(InitialOrder model);
        string MakePayment(object input);
    }
}