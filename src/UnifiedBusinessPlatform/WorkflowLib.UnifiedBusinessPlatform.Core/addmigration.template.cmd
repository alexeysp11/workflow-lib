
dotnet build

dotnet ef migrations add InitialCreate --project core/WorkflowLib.UnifiedBusinessPlatform.Core.csproj --startup-project webapp/WorkflowLib.UnifiedBusinessPlatform.csproj
dotnet ef database update --project core/WorkflowLib.UnifiedBusinessPlatform.Core.csproj --startup-project webapp/WorkflowLib.UnifiedBusinessPlatform.csproj
