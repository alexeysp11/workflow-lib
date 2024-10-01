
dotnet build

dotnet ef migrations add InitialCreate --project core/WorkflowLib.Examples.UnifiedBusinessPlatform.Core.csproj --startup-project webapp/WorkflowLib.Examples.UnifiedBusinessPlatform.csproj
dotnet ef database update --project core/WorkflowLib.Examples.UnifiedBusinessPlatform.Core.csproj --startup-project webapp/WorkflowLib.Examples.UnifiedBusinessPlatform.csproj
