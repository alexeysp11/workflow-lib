using Microsoft.EntityFrameworkCore;
using WorkflowLib.ECommerce.FoodDelivery.Core.DbContexts;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.ECommerce.FoodDelivery.Core.Dal
{
    public static class OrganizationDao
    {
        /// <summary>
        /// Get organization.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Organization? GetOrganization(FoodDeliveryDbContext context)
        {
            return context.Organizations
                .Include(x => x.Company)
                .FirstOrDefault();
        }
    }
}
