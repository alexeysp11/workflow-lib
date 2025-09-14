
dotnet build

dotnet ef migrations add InitialCreate --project VelocipedeUtils.ECommerce.FoodDelivery.Core/VelocipedeUtils.ECommerce.FoodDelivery.Core.csproj --startup-project VelocipedeUtils.ECommerce.FoodDelivery.WebApi/VelocipedeUtils.ECommerce.FoodDelivery.WebApi.csproj
dotnet ef database update --project VelocipedeUtils.ECommerce.FoodDelivery.Core/VelocipedeUtils.ECommerce.FoodDelivery.Core.csproj --startup-project VelocipedeUtils.ECommerce.FoodDelivery.WebApi/VelocipedeUtils.ECommerce.FoodDelivery.WebApi.csproj
