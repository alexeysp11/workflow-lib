# Models.Business

[English](README.md) | [Русский](README.ru.md)

This project is an implementation of a shared object model for business entities used within [workflow-lib](https://github.com/alexeysp11/workflow-lib).

## Idea

The [workflow-lib](https://github.com/alexeysp11/workflow-lib) library was created to solve the problem of code duplication and disparate object models when developing business applications. For example, I often had to create identical entities and services in different projects, which led to a loss of time and complicated support. It is worth noting that each project had its own repository, which complicated the integration between projects and the ability to change the object model.

As a result, it was decided to create a mono-repository, which included most of the previously created projects, as well as a common object model for representing data in the DB. This approach allows:
- Avoid code duplication.
- Ensure data consistency between projects.
- Reduce development time by reusing ready-made components.
- Simplify refactoring and dependency management.

The `WorkflowLib.Shared.Models.Business` project contains a common object model for business entities.

## Examples of classes

This part of the library provides classes for business:
- Common: [business task](BusinessTask.cs), [risk](Risk.cs), etc.
- Business documents: [bill](BusinessDocuments/Bill.cs), [delivery order](BusinessDocuments/DeliveryOrder.cs), [employment contract](BusinessDocuments/EmploymentContract.cs), etc.
- Customers: [customer](Customers/Customer.cs), [company](Customers/Company.cs), [contact](Customers/Contact.cs), etc.
- Information system: [employee](InformationSystem/Employee.cs), [user account](InformationSystem/UserAccount.cs), [working day](InformationSystem/WorkingDay.cs), etc.
- Monetary: [paycheck](Monetary/Paycheck.cs), [payment](Monetary/Payment.cs), [pay rate](Monetary/PayRate.cs), etc.
- Products: [product](Products/Product.cs), [product category](Products/ProductCategory.cs), [project](Products/Project.cs).
- Responsibilities: [employee responsibility](Responsibilities/EmployeeResponsibility.cs), [employer responsibility](Responsibilities/EmployerResponsibility.cs).
- Social communication: [message](SocialCommunication/MessageWF.cs).
