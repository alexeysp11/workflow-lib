# HttpServerWF Class 

*Namespace*: [Cims.WorkflowLib.NetworkAPIs](Cims.WorkflowLib.NetworkAPIs.md)

HTTP server.

## Constructors 

### HttpServerWF(Action\<HttpListener\>, Action\<HttpListenerContext\>)

Default constructor.

```C#
public HttpServerWF(
    System.Action<HttpListener> addPrefixes, 
    System.Action<HttpListenerContext> processRequest);
```

#### Parameters 

- `addPrefixes`: [Action](https://learn.microsoft.com/en-us/dotnet/api/system.action-1)<[HttpListener](https://learn.microsoft.com/en-us/dotnet/api/system.net.httplistener)>

Reference to the method that adds Uniform Resource Identifier (URI) prefixes for HttpListener object.

- `processRequest`: [Action](https://learn.microsoft.com/en-us/dotnet/api/system.action-1)<[HttpListenerContext](https://learn.microsoft.com/en-us/dotnet/api/system.net.httplistenercontext)>

Reference to the method that handles HTTP request.

## Methods 

### CreateWebServer()

Create web server as HttpListener.

```C#
void CreateWebServer();
```

#### Examples 

Examples.
