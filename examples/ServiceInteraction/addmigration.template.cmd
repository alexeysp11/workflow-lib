dotnet ef migrations add AddNullableParentInstances --project Core/WorkflowLib.Examples.ServiceInteraction.Core.csproj --startup-project InitializeDb/WorkflowLib.Examples.ServiceInteraction.InitializeDb.csproj
dotnet ef database update --project Core/WorkflowLib.Examples.ServiceInteraction.Core.csproj --startup-project InitializeDb/WorkflowLib.Examples.ServiceInteraction.InitializeDb.csproj
