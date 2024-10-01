
dotnet build

dotnet ef migrations add InitialCreate --project core/WorkflowLib.Examples.EmployeesMvc.Core.csproj --startup-project webapp/WorkflowLib.Examples.EmployeesMvc.csproj
dotnet ef database update --project core/WorkflowLib.Examples.EmployeesMvc.Core.csproj --startup-project webapp/WorkflowLib.Examples.EmployeesMvc.csproj
