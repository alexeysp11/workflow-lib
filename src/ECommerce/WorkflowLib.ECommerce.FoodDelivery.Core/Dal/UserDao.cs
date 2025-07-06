using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.BusinessDocuments;
using WorkflowLib.Shared.Models.Business.Customers;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public class UserDao
    {
        /// <summary>
        /// Get customer by user UID.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="userUid">Specified user UID</param>
        /// <returns></returns>
        public static Customer? GetCustomerByUserUid(FoodDeliveryDbContext context, string? userUid)
        {
            return context.Customers
                .Include(x => x.UserAccount)
                .FirstOrDefault(x => x.UserAccount != null && x.UserAccount.Uid == userUid);
        }

        /// <summary>
        /// Get responsible employee gy group name.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userGroupName"></param>
        public static void GetResponsibleEmployeeByGroupName(FoodDeliveryDbContext context, string userGroupName)
        {
            //var userGroup = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.Name == userGroupName);
            //if (userGroup == null)
            //    throw new Exception("Specified user group is not defined");

            //var userAccountIds = (from userAccount in userGroup.Users select userAccount.Id).ToList();
            //var potentialExecutors = 
            //    (from employee in context.Employees 
            //    where employee.UserAccounts != null && employee.UserAccounts.Any(ua => userAccountIds.Contains(ua.Id))
            //    select employee).ToList();
            //if (potentialExecutors == null || !potentialExecutors.Any())
            //    throw new Exception("The list of potential executors is null or empty");

            //var selectedEmployee = potentialExecutors[rand.Next(potentialExecutors.Count)];
            //if (selectedEmployee == null)
            //    throw new Exception("Randomly selected employee is null");
        }

        /// <summary>
        /// Get admin user account.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserAccount? GetAdminUserAccount(FoodDeliveryDbContext context)
        {
            return context.UserAccounts.FirstOrDefault();
        }
    }
}
