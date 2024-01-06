using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.BusinessDocuments;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Example01.Models;

/// <summary>
/// Model for transferring products from warehouse to kitchen (shipping point, destination, start time, end time, products, ingredients).
/// </summary>
public class DeliveryWh2Kitchen : DeliveryOperation, IBusinessEntityWF
{
    /// <summary>
    /// Initial orders.
    /// </summary>
    public ICollection<InitialOrder> InitialOrders { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ICollection<InitialOrderProduct> InitialOrderProducts { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ICollection<InitialOrderIngredient> InitialOrderIngredients { get; set; }
}
