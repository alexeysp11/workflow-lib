
dotnet build

dotnet ef migrations add InitialCreate --project VelocipedeUtils.UnifiedBusinessPlatform.Core/VelocipedeUtils.UnifiedBusinessPlatform.Core.csproj --startup-project VelocipedeUtils.UnifiedBusinessPlatform/VelocipedeUtils.UnifiedBusinessPlatform.csproj
dotnet ef database update --project VelocipedeUtils.UnifiedBusinessPlatform.Core/VelocipedeUtils.UnifiedBusinessPlatform.Core.csproj --startup-project VelocipedeUtils.UnifiedBusinessPlatform/VelocipedeUtils.UnifiedBusinessPlatform.csproj
