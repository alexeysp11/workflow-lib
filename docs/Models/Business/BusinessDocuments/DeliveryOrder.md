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

### Number

Number of the delivery order.

```C#
public string Number { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### OpenOrderDt

Timestamp when the delivery order was created.

```C#
public System.DateTime OpenOrderDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

### CloseOrderDt

Timestamp when the delivery order was closed.

```C#
public System.DateTime CloseOrderDt { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)

### CustomerUid

Customer UID of the delivery order.

```C#
public string CustomerUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### CustomerName

Customer name of the delivery order.

```C#
public string CustomerName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### CompanyUid

Company UID of the delivery order.

```C#
public string CompanyUid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### CompanyName

Company name of the delivery order.

```C#
public string CompanyName { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### DeliveryMethod

Delivery method.

```C#
public DeliveryMethod DeliveryMethod { get; set; }
```

#### Property Value

[DeliveryMethod](../DeliveryMethod.md)

### PreparingOperations

Preparing operations for the delivery order.

```C#
public ICollection<BusinessOperation> PreparingOperations { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[BusinessOperation](../BusinessOperation.md)>

### DeliveryOperation

Delivery operation.

```C#
public BusinessOperation DeliveryOperation { get; set; }
```

#### Property Value

[BusinessOperation](../BusinessOperation.md)

### Products

Products associated with the delivery order.

```C#
public ICollection<Product> Products { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Product](Product.md)>

### ProductsPrice

Price of the products.

```C#
public decimal ProductsPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### AdditonalPrice

Additonal price of the delivery order.

```C#
public decimal AdditonalPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### DeliveryPrice

Price for the delivery.

```C#
public decimal DeliveryPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### TaxPrice

Taxes of the delivery order.

```C#
public decimal TaxPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### TotalPrice

Total price of the delivery order.

```C#
public decimal TotalPrice { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### Origin

Initial address of the delivery.

```C#
public Address Origin { get; set; }
```

#### Property Value

[Address](../Address.md)

### Destination

Final address of the delivery (destination).

```C#
public Address Destination { get; set; }
```

#### Property Value

[Address](../Address.md)

### Payments

Payments made within the delivery order.

```C#
public ICollection<Payment> Payments { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Payment](../Monetary/Payment.md)>

### Status

Status of the delivery order.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)
