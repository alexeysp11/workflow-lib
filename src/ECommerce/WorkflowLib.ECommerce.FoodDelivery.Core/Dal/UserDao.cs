using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public class UserDao
    {
        /// <summary>
        /// Get customer by user UID.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userUid">Specified user UID</param>
        /// <returns></returns>
        public static Customer? GetCustomerByUserUid(FoodDeliveryDbContext context, string? userUid)
        {
            return context.Customers
                .Include(x => x.UserAccount)
                .FirstOrDefault(x => x.UserAccount != null && x.UserAccount.Uid == userUid);
        }
    }
}
