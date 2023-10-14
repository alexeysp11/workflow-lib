# NetworkAppSettings

Namespace: [Cims.WorkflowLib.Models.AppSettings](Cims.WorkflowLib.Models.AppSettings.md)

Class for storing confidurations related to the core server.

## Constructors

### NetworkAppSettings()

```C#
public NetworkAppSettings();
```

## Properties

### ServerAddress

Network address of the server application.

```C#
public string ServerAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Network address of the server application.

### ClientAddress

Network address of the client application.

```C#
public string ClientAddress { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Network address of the client application.

### Environment

String representation of the environment (e.g. test, production).

```C#
public string Environment { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

String representation of the environment.

### HttpPaths

HTTP paths.

```C#
public string[] HttpPaths { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)[]

HTTP paths.

### HttpPathsDbg

HTTP paths used for testing and debugging the server.

```C#
public string[] HttpPathsDbg { get; set; }
```

#### Property Value

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)[]

HTTP paths used for testing and debugging the server.

### PrintWebPaths

Allows to print web paths which API server uses to listen to requests.

```C#
public bool PrintWebPaths { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Allows to print web paths which API server uses to listen to requests.

### PrintHttpRequestProcInfo

Allows to print debug information about processing HTTP requests.

```C#
public bool PrintHttpRequestProcInfo { get; set; }
```

#### Property Value

[Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean)

Allows to print debug information about processing HTTP requests.
