using Microsoft.EntityFrameworkCore;
using VelocipedeUtils.ECommerce.FoodDelivery.Core.DbContexts;
using VelocipedeUtils.Shared.Models.Business.InformationSystem;

namespace VelocipedeUtils.ECommerce.FoodDelivery.Core.Dal
{
    public static class OrganizationDao
    {
        /// <summary>
        /// Get organization.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <returns></returns>
        public static Organization? GetOrganization(FoodDeliveryDbContext context)
        {
            return context.Organizations
                .Include(x => x.Company)
                .FirstOrDefault();
        }
    }
}
