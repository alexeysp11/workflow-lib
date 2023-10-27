# Recipe Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.Products](Cims.WorkflowLib.Models.Business.Products.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

## Constructors 

### Recipe()

Default constructor.

```C#
public Recipe();
```

## Properties 

### Product

Product.

```C#
public Product Product { get; set; }
```

#### Property Value

[Product](Product.md)

### Ingredients

Ingredients.

```C#
public ICollection<Ingredient> Ingredients { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Ingredient](Ingredient.md)>

### Instruction

Instruction.

```C#
public string Instruction { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)
