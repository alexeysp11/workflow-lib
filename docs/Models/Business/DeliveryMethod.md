# DeliveryMethod Class 

Namespace: [Cims.WorkflowLib.Models.Business](Cims.WorkflowLib.Models.Business.md)

Delivery method.

## Constructors 

### DeliveryMethod()

Default constructor.

```C#
public DeliveryMethod();
```

## Properties

### Id

ID of the delivery method.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of the delivery method.

### Uid

UID of the delivery method.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the delivery method.

### Name

Name of the delivery method.

```C#
public string Name { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Name of the delivery method.

### Description

Description of the delivery method.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Description of the delivery method.

### Type

Type of the delivery method.

```C#
public DeliveryMethodType Type { get; set; }
```

#### Property Value

[DeliveryMethodType](DeliveryMethodType.md)

Type of the delivery method.

### Price

Price of the delivery method.

```C#
public decimal Price { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Price of the delivery method.
