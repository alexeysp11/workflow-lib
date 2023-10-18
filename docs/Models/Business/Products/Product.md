# Product Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.Products](Cims.WorkflowLib.Models.Business.Products.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Product.

## Constructors 

### Product()

Default constructor.

```C#
public Product();
```

## Properties

### Price

Price of the product.

```C#
public decimal Price { get; set; }
```

#### Property Value

[Decimal](https://learn.microsoft.com/en-us/dotnet/api/system.decimal)

### Quantity

Quantity of the product.

```C#
public int Quantity { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)

### ProductCategory

Category of the product.

```C#
public ProductCategory ProductCategory { get; set; }
```

#### Property Value

[ProductCategory](ProductCategory.md)

### PictureUrl

Picture URL of the product.

```C#
public string PictureUrl { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### PictureDescription

Picture description of the product.

```C#
public string PictureDescription { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)
