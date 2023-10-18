# ProductCategory Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.Products](Cims.WorkflowLib.Models.Business.Products.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

Product category.

## Constructors 

### ProductCategory()

Default constructor.

```C#
public ProductCategory();
```

## Properties

### Products

Products associated with the product category.

```C#
public ICollection<Product> Products { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Product](Product.md)>

### PictureUrl

Picture URL of the product category.

```C#
public string PictureUrl { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

### PictureDescription

Picture description of the product category.

```C#
public string PictureDescription { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)
