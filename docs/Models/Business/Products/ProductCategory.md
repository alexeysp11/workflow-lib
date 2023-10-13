# ProductCategory Class 

Namespace: [Cims.WorkflowLib.Models.Business.Products](Cims.WorkflowLib.Models.Business.Products.md)

Product category.

## Constructors 

### ProductCategory()

Default constructor.

```C#
public ProductCategory();
```

## Properties

### Id

ID of the product category.

```C#
public int Id { get; set; }
```

#### Property Value

[Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)

ID of the product category.

### Uid

UID of the product category.

```C#
public string Uid { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

UID of the product category.

### Name

Name of the product category.

```C#
public string Name { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Name of the product category.

### Description

Description of the product category.

```C#
public string Description { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Description of the product category.

### Products

Products with the product category.

```C#
public ICollection<Product> Products { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Product](Product.md)>

Products with the product category.


### PictureUrl

Picture URL of the product category.

```C#
public string PictureUrl { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Picture URL of the product category.

### PictureDescription

Picture description of the product category.

```C#
public string PictureDescription { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Picture description of the product category.
