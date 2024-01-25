using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Delivery;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Examples.DbConnections.PostgreSQL.Example01.Resolvers;

IEnumerable<Product> menuItems = new List<Product>();
IEnumerable<ProductCategory> categories = new List<ProductCategory>();
try
{
    menuItems = new MenuResolver().GetMenu();
    categories = menuItems.Select(x => x.ProductCategory).Distinct();
    foreach (var category in categories)
    {
        System.Console.WriteLine($"Name: {category.Name}; Description: {category.Description}");
    }
}
catch (System.Exception ex)
{
    System.Console.WriteLine(ex);
}
