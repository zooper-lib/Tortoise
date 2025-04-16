# Zooper.Tortoise

<img src="icon.png" alt="Zooper.Tortoise" width="256" />

Zooper.Tortoise is a .NET library that simplifies the implementation of the "Strong Type" pattern (also known as "Strongly Typed IDs" or "Primitive Obsession" solution) in C# applications.

## What is the Strong Type Pattern?

The Strong Type pattern helps you avoid "Primitive Obsession" by wrapping primitive types in domain-specific types, improving:

- **Type Safety**: Prevent mixing different IDs/values that share the same primitive type
- **Self-Documentation**: Clear identification of what a value represents
- **Encapsulation**: Add domain-specific behavior to primitive values
- **Validation**: Ensure values meet domain requirements

## Features

- Provides base classes and interfaces to easily create strong types
- Supports both class and record implementations
- Automatic generation of converters through source generators:
  - Entity Framework Core Value Converters (only generated if Microsoft.EntityFrameworkCore is referenced)
  - JSON Converters (Newtonsoft.Json)
  - Type Converters

## Installation

```bash
dotnet add package Zooper.Tortoise
```

## Usage

### Creating a Strong Type Record

```csharp
using System;
using Zooper.Tortoise.Generators.Attributes.Attributes;
using Zooper.Tortoise.Interfaces;

namespace YourNamespace;

[GenerateConverters]
public partial record UserId(Guid Value) : StrongTypeRecord<Guid, UserId>(Value)
{
    // The source generator will implement these partial classes
    public partial class UserIdValueConverter;
    public partial class UserIdNewtonsoftJsonConverter;
    public partial class UserIdTypeConverter;
}
```

### Creating a Strong Type Class

```csharp
using System;
using Zooper.Tortoise.Generators.Attributes.Attributes;
using Zooper.Tortoise.Interfaces;

namespace YourNamespace;

[GenerateConverters]
public partial class OrderId : StrongTypeClass<int, OrderId>
{
    public OrderId(int value) : base(value)
    {
    }

    // The source generator will implement these partial classes
    public partial class OrderIdValueConverter;
    public partial class OrderIdNewtonsoftJsonConverter;
    public partial class OrderIdTypeConverter;
}
```

### Using Strong Types with Entity Framework Core

```csharp
public class User
{
    public UserId Id { get; set; }
    // Other properties...
}

public class YourDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure value converter for UserId
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasConversion(new UserId.UserIdValueConverter());
    }
}
```

### Using Strong Types with JSON Serialization

```csharp
// Add the converter to your serializer settings
var settings = new JsonSerializerSettings
{
    Converters = new List<JsonConverter>
    {
        new UserId.UserIdNewtonsoftJsonConverter()
    }
};

// Serialize and deserialize with proper conversion
var user = new User { Id = new UserId(Guid.NewGuid()) };
var json = JsonConvert.SerializeObject(user, settings);
var deserializedUser = JsonConvert.DeserializeObject<User>(json, settings);
```

## Benefits of Using Zooper.Tortoise

- **Reduced Boilerplate**: Base classes handle equality comparison, ToString(), etc.
- **Type Safety**: Compiler prevents passing the wrong ID type
- **Automatic Conversion**: Generated converters handle serialization seamlessly
- **Clean API**: Strongly typed interfaces improve API design

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details. 