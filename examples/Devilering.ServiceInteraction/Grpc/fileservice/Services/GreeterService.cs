using VelocipedeUtils.Examples.Delivering.ServiceInteraction.Grpc.Core;
using VelocipedeUtils.Examples.Delivering.ServiceInteraction.Grpc;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.Grpc.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
