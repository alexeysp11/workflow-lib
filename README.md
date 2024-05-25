# workflow-lib 

[English](README.md) | [Русский](README.ru.md)

This project is a comprehensive library that provides a wide range of functionalities for ERP/CRM systems. 

Overall, this library is a powerful tool that can be used in ERP/CRM systems to streamline and automate various business processes. 
It offers a wide range of functionalities and data models that can be customized to meet the specific needs of any organization.

Developers working on applications that require the functionalities provided by the library could use this application. 
Companies in industries such as logistics, finance, and document management could potentially benefit from using applications that incorporate this library.

## Technologies 

- Target frameworks:
  - .NET Core 3.1 (C# 8.0)
  - .NET 6 (C# 10)
- [itext7](https://github.com/itext/itext7-dotnet)
- [itext7.pdfhtml](https://github.com/itext/i7n-pdfhtml)
- [Open XML SDK](https://github.com/dotnet/Open-XML-SDK)
- [Open-Xml-PowerTools](https://github.com/alexeysp11/Open-Xml-PowerTools.git)
- [RabbitMQ](https://github.com/rabbitmq/rabbitmq-dotnet-client)
- [MailKit](https://github.com/jstedfast/MailKit) and [MimeKit](https://github.com/jstedfast/MimeKit)
- [Nethereum.Web3](https://github.com/Nethereum/Nethereum/tree/master/src/Nethereum.Web3)

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
