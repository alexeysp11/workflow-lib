dotnet ef migrations add InitialCreate --project BL/WorkflowLib.Examples.ServiceInteraction.BL.csproj --startup-project InitializeDb/WorkflowLib.Examples.ServiceInteraction.InitializeDb.csproj
dotnet ef database update --project BL/WorkflowLib.Examples.ServiceInteraction.BL.csproj --startup-project InitializeDb/WorkflowLib.Examples.ServiceInteraction.InitializeDb.csproj
