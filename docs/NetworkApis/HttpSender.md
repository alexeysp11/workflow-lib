# HttpSender

Namespace: [Cims.WorkflowLib.NetworkApis](Cims.WorkflowLib.NetworkApis.md)

`HttpSender` is a class for **sending objects via HTTP**.

## Constructors 

### HttpSender()

Default constructor.

```C#
public HttpSender();
```

## Methods

### Send(String, Object)

`Send()` is a method for sending an object via HTTP **synchronously**.

```C#
public string Send(string url, object parameter);
```

#### Parameters 

- `url`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

URL address to send an object to.

- `parameter`: [Object](https://learn.microsoft.com/en-us/dotnet/api/system.object)

An object that is going to be sent.

#### Returns 

[String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

String response.

#### Examples 

Example of using `Send()` method: 
```C#
        try
        {
            ...
            // 
            var responseStr = new HttpSender().Send("https://localhost:7251/Auth/VerifyUserCredentials", request);
            response = JsonSerializer.Deserialize<VUCResponse>(responseStr, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (System.Exception ex)
        {
            ...
        }
```

### SendAsync(String, Object, String)

`SendAsync()` is a method for sending an object via HTTP **asynchronously**.

```C#
public async Task<ApiOperation> SendAsync(string url, object parameter, string methodName = "");
```

#### Parameters 

- `url`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

URL address to send an object to.

- `parameter`: [Object](https://learn.microsoft.com/en-us/dotnet/api/system.object)

An object that is going to be sent.

- `methodName`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

Method name (optional).

#### Returns 

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<[ApiOperation](../Models/ApiOperation.md)>

All information about HTTP request incapsulated into [ApiOperation](../Models/ApiOperation.md) object.

#### Examples

Example of using `SendAsync()` method: 
```C#
        try
        {
            ...
            // 
            ApiOperation httpResponse = new ApiOperation();
            var task = Task.Run(async () => 
            {
                httpResponse = await new HttpSender().SendAsync("https://localhost:7251/Auth/AddUser", request, "Auth/AddUser");
            });
            task.Wait();
            response = JsonSerializer.Deserialize<UserCreationResult>(httpResponse.Response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (System.Exception ex)
        {
            ...
        }
```

### SendMultipleAsync(String, List\<Object\>, String)

`SendMultipleAsync()` is a method for sending **multiple objects** via HTTP **asynchronously**.

```C#
public async Task<List<ApiOperation>> SendMultipleAsync(string url, List<object> parameters, string methodName = "");
```

#### Parameters 

- `url`: [String](https://learn.microsoft.com/en-us/dotnet/api/system.string)

URL address to send an object to.

- `parameters`: [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[Object](https://learn.microsoft.com/en-us/dotnet/api/system.object)>

List of objects that are going to be sent.

- `methodName`: [Object](https://learn.microsoft.com/en-us/dotnet/api/system.object)

Method name (optional).

#### Returns 

[Task](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)\<[ApiOperation](../Models/ApiOperation.md)>>

All information about HTTP requests incapsulated into [ApiOperation](../Models/ApiOperation.md) object.

#### Examples

Example of using `SendMultipleAsync()` method: 
```C#
        var httpSender = new HttpSender();
        var responses = await httpSender.SendMultipleAsync(
            "https://localhost:7251/Auth/VerifyUserCredentials", 
            new List<object>
            {
                new
                {
                    Login = "string",
                    Password = "string"
                },
                new
                {
                    Login = "user1",
                    Password = "pswd"
                }
            },
            "HttpSender.SendMultipleAsync");
        var executionTime = responses[0].ExecutionTime;
        System.Console.WriteLine($"Method: {responses[0].MethodName}");
        System.Console.WriteLine($"Request: {responses[0].Request}");
        System.Console.WriteLine($"Response: {responses[0].Response}");
        System.Console.WriteLine($"Started: {executionTime.DateTimeBegin}");
        System.Console.WriteLine($"Finished: {executionTime.DateTimeEnd}");
        System.Console.WriteLine($"Executed in: {executionTime.TimeDifference.Seconds}:{executionTime.TimeDifference.Milliseconds}");
```

