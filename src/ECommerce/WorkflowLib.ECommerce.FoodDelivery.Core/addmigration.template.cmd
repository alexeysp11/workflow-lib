
dotnet build

dotnet ef migrations add InitialCreate --project WorkflowLib.ECommerce.FoodDelivery.Core/WorkflowLib.ECommerce.FoodDelivery.Core.csproj --startup-project WorkflowLib.ECommerce.FoodDelivery.WebApi/WorkflowLib.ECommerce.FoodDelivery.WebApi.csproj
dotnet ef database update --project WorkflowLib.ECommerce.FoodDelivery.Core/WorkflowLib.ECommerce.FoodDelivery.Core.csproj --startup-project WorkflowLib.ECommerce.FoodDelivery.WebApi/WorkflowLib.ECommerce.FoodDelivery.WebApi.csproj
