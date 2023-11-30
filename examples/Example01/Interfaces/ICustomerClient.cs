using Cims.WorkflowLib.Models.Business.Monetary;
using Cims.WorkflowLib.Example01.Models;

namespace Cims.WorkflowLib.Example01.Interfaces
{
    public interface ICustomerClient
    {
        string MakeOrder(PlaceOrderModel model);
        string MakePayment(object input);
    }
}