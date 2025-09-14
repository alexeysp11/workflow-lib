using VelocipedeUtils.Shared.Models.Business;
using VelocipedeUtils.Shared.Models.Business.Delivery;
using VelocipedeUtils.Shared.Models.Business.Products;
using VelocipedeUtils.Examples.DbConnections.PostgreSQL.Example01.Resolvers;

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
