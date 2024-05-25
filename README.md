# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

This project is a comprehensive library that provides a wide range of functionalities for ERP/CRM systems. 

Overall, this library is a powerful tool that can be used in ERP/CRM systems to streamline and automate various business processes. 
It offers a wide range of functionalities and data models that can be customized to meet the specific needs of any organization.

Who can use this library:
- Developers working on applications that require the functionalities provided by the library could use this application. 
- Companies in industries such as logistics, finance, and document management could potentially benefit from using applications that incorporate this library.

## Projects inside the library

- [AuthenticationService](src/AuthenticationService/README.md)
- [CodeExtensions](src/CodeExtensions/README.md)
- [Communication](src/Communication/README.md)
- [Models](src/Models/README.md)
- [Models.Business](src/Models.Business/README.md)
- [Office](src/Office/README.md)
- [ServiceDiscoveryBpm](src/ServiceDiscoveryBpm/README.md)

## How to use 

You can use this library in C# code directly:

1. Clone the repository: 
```
git clone https://github.com/alexeysp11/Open-Xml-PowerTools.git 
git clone https://github.com/alexeysp11/workflow-lib.git
```

2. Add the reference to the repository in the `csproj` file of your target project: 
```XML
  <ItemGroup>
    <ProjectReference Include="../../workflow-lib/src/WorkflowLib.csproj" />
  </ItemGroup>
```
