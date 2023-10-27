# Ingredient Class 

*Namespace*: [Cims.WorkflowLib.Models.Business.Products](Cims.WorkflowLib.Models.Business.Products.md)

*Implements*: [IBusinessEntityWF](../IBusinessEntityWF.md)

*Inherits*: [BusinessEntityWF](../BusinessEntityWF.md)

## Constructors 

### Ingredient()

Default constructor.

```C#
public Ingredient();
```

## Properties 

### Product

Product (main ingredient).

```C#
public Product Product { get; set; }
```

#### Property Value

[Product](Product.md)

### SubstituteIngredients

Substitute ingredients.

```C#
public ICollection<Ingredient> SubstituteIngredients { get; set; }
```

#### Property Value

[ICollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1)<[Ingredient](Ingredient.md)>
