
dotnet build

dotnet ef migrations add InitialCreate --project WorkflowLib.UnifiedBusinessPlatform.Core/WorkflowLib.UnifiedBusinessPlatform.Core.csproj --startup-project WorkflowLib.UnifiedBusinessPlatform/WorkflowLib.UnifiedBusinessPlatform.csproj
dotnet ef database update --project WorkflowLib.UnifiedBusinessPlatform.Core/WorkflowLib.UnifiedBusinessPlatform.Core.csproj --startup-project WorkflowLib.UnifiedBusinessPlatform/WorkflowLib.UnifiedBusinessPlatform.csproj
