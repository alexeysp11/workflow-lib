using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Delivery;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Examples.DbConnections.PostgreSQL.Example01.Resolvers;

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
