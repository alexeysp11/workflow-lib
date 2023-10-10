# Payment Class 

Namespace: [Cims.WorkflowLib.Models.Business.Monetary](Cims.WorkflowLib.Models.Business.Monetary.md)

Payment.

## Properties 

### Id

ID of the payment.

```C#
public int Id { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)

ID of the payment.

### Uid

UID of the payment.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the payment.

### Type

Type of the payment (card, cash).

```C#
public string Type { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Type of the payment (card, cash).

### Method

Method of the payment (credit/debit card, PayPal).

```C#
public string Method { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Method of the payment (credit/debit card, PayPal).

### CardNumber

Card number.

```C#
public string CardNumber { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Card number.

### Amount

Amount of the payment.

```C#
public float Amount { get; set; }
```

#### Property Value

[Single](https://learn.microsoft.com/en-us/dotnet/api/system.single)

Amount of the payment.

### Payer

Payer of the payment.

```C#
public string Payer { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Payer of the payment.

### Receiver

Receiver of the payment.

```C#
public string Receiver { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Receiver of the payment.

### Status

Status of the payment.

```C#
public string Status { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Status of the payment.
