# Payment Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.Monetary](Cims.WorkflowLib.Models.Business.Monetary.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Payment.

## Properties 

### Type

Type of the payment (card, cash).

```C#
public string Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Method

Method of the payment (credit/debit card, PayPal).

```C#
public string Method { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### CardNumber

Card number.

```C#
public string CardNumber { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Amount

Amount of the payment.

```C#
public decimal Amount { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### Payer

Payer of the payment.

```C#
public string Payer { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Receiver

Receiver of the payment.

```C#
public string Receiver { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Status

Status of the payment.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### Date

Date of the payment.

```C#
public System.DateTime Date { get; set; }
```

#### Property Value

[DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime)
