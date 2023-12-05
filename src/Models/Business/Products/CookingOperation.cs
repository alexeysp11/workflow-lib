using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Cooking operation.
    /// </summary>
    public class CookingOperation : BusinessTask, IBusinessEntityWF
    {
        /// <summary>
        /// Collection of recipes.
        /// </summary>
        public ICollection<Recipe> Recipes { get; set; }
    }
}