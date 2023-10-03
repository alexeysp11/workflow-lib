# DynamicCompiling

Namespace: [Cims.WorkflowLib.Dynamical](Cims.WorkflowLib.Dynamical.md)

`DynamicCompiling` is class for **dynamically compiling** a string containing a C# code.

## Constructors 

### DynamicCompiling()

Default constructor.

```C#
public DynamicCompiling();
```

## Methods 

### CompileAndRunCSharpString(String, String, String)

Method for compiling a string containing C# code and run it.

```C#
public string CompileAndRunCSharpString(string code, string assemblyName, string instanceName);
```

#### Parameters 

- `code`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

A string that contains C# code.

- `assemblyName`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Assembly name.

- `instanceName`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Instance name.

#### Returns

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Result of the method that was compiled and executed.

#### Examples

Example of using `DynamicCompiling.CompileAndRunCSharpString()`: 

```C#
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Cims.WorkflowLib.Dynamical; 

namespace Cims.Tests.WorkflowLib.Dynamical
{
    public class DynamicCompilingTest
    {
        private string FolderName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), typeof(DynamicCompiling).ToString().Split('.').Last()); 

        // 
        [Fact]
        public void CompileAndRunCSharpString_CorrectParameters_InstanceCreated()
        {
            // Arrange 
            DynamicCompiling compiler = new DynamicCompiling(); 
            var code = @"
using System;
using System.Collections.Generic;

namespace Debuggable
{
    public class HelloWorld
    {
        public string DoWork()
        {
            return ""Hello world"";
        }
    }
}
            ";
            string assemblyName = "TestCompiledAssembly"; 
            string instanceName = "Debuggable.HelloWorld"; 

            // Act 
            string result = compiler.CompileAndRunCSharpString(code, assemblyName, instanceName); 

            // Assert 
            Assert.True(result == "Hello world"); 
        }
    }
}
```
