using VelocipedeUtils.Shared.Models.Business.Monetary;
using VelocipedeUtils.Shared.Models.Business.BusinessDocuments;

namespace VelocipedeUtils.Examples.Delivering.Example01.Interfaces
{
    public interface ICustomerClient
    {
        string MakeOrder(InitialOrder model);
        string MakePayment(object input);
    }
}