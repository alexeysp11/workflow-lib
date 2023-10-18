# Customer Class

*Namespace*: [Cims.WorkflowLib.Models.Business.Customers](Cims.WorkflowLib.Models.Business.Customers.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Customer. 

## Constructors

### Customer()

Default constructor.

```C#
public Customer();
```

## Properties 

### Id

ID of a customer.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of a customer.

### Uid

UID of a customer.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of a customer.

### UserAccount

User account of a customer.

```C#
public UserAccount UserAccount { get; set; }
```

#### Property Value

[UserAccount](../InformationSystem/UserAccount.md)

User account of a customer.
