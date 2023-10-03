# HttpSender

`HttpSender` is a class for **sending objects via HTTP**.

Namespace: `Cims.WorkflowLib.NetworkApis`.

## Send()

`Send()` is a method for sending an object via HTTP **synchronously**.

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

## SendAsync()

`SendAsync()` is a method for sending an object via HTTP **asynchronously**.

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

## SendMultipleAsync()

`SendMultipleAsync()` is a method for sending **multiple objects** via HTTP **asynchronously**.

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

