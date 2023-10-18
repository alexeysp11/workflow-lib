# DeliveryOrder Class

*Namespace*: [Cims.WorkflowLib.Models.Business.BusinessDocuments](Cims.WorkflowLib.Models.Business.BusinessDocuments.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Delivery order.

## Constructors 

### DeliveryOrder()

Default constructor.

```C#
public DeliveryOrder();
```

## Properties 

### Id

ID of the delivery order.

```C#
public long Id { get; set; }
```

#### Property Value

[Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64)

ID of the delivery order.

### Uid

UID of the delivery order.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the delivery order.

### Name

Name of the delivery order.

```C#
public string Name { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Name of the delivery order.

### Number

Number of the delivery order.

```C#
public string Number { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Number of the delivery order.

### OpenOrderDt

Timestamp when the delivery order was created.

```C#
public DateTime OpenOrderDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the delivery order was created.

### CloseOrderDt

Timestamp when the delivery order was closed.

```C#
public DateTime CloseOrderDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

Timestamp when the delivery order was closed.

### CustomerUid

Customer UID of the delivery order.

```C#
public string CustomerUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Customer UID of the delivery order.

### CustomerName

Customer name of the delivery order.

```C#
public string CustomerName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Customer name of the delivery order.

### CompanyUid

Company UID of the delivery order.

```C#
public string CompanyUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Company UID of the delivery order.

### CompanyName

Company name of the delivery order.

```C#
public string CompanyName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Company name of the delivery order.

### DeliveryMethod

Delivery method.

```C#
public DeliveryMethod DeliveryMethod { get; set; }
```

#### Property Value

[DeliveryMethod](../DeliveryMethod.md)

Delivery method.

### PreparingOperations

Preparing operations for the delivery order.

```C#
public ICollection<BusinessOperation> PreparingOperations { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[BusinessOperation](../BusinessOperation.md)>

Preparing operations for the delivery order.

### DeliveryOperation

Delivery operation.

```C#
public BusinessOperation DeliveryOperation { get; set; }
```

#### Property Value

[BusinessOperation](../BusinessOperation.md)

Delivery operation.

### Products

Products associated with the delivery order.

```C#
public ICollection<Product> Products { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Product](Product.md)>

Products associated with the delivery order.

### ProductsPrice

Price of the products.

```C#
public decimal ProductsPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Price of the products.

### AdditonalPrice

Additonal price of the delivery order.

```C#
public decimal AdditonalPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Additonal price of the delivery order.

### DeliveryPrice

Price for the delivery.

```C#
public decimal DeliveryPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Price for the delivery.

### TaxPrice

Taxes of the delivery order.

```C#
public decimal TaxPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Taxes of the delivery order.

### TotalPrice

Total price of the delivery order.

```C#
public decimal TotalPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

Total price of the delivery order.

### Origin

Initial address of the delivery.

```C#
public Address Origin { get; set; }
```

#### Property Value

[Address](../Address.md)

Initial address of the delivery.

### Destination

Final address of the delivery (destination).

```C#
public Address Destination { get; set; }
```

#### Property Value

[Address](../Address.md)

Final address of the delivery (destination).

### Payments

Payments made within the delivery order.

```C#
public ICollection<Product> Payments { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Product](Product.md)>

Payments made within the delivery order.

### Status

Status of the delivery order.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Status of the delivery order.
