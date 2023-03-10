using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        _logger.LogInformation("call SayHello at {DT}.", DateTime.UtcNow.ToLongTimeString());

        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name,
            Uuid = Ulid.NewUlid().ToString(),
            Timestamp = Timestamp.FromDateTime(DateTime.UtcNow),
        });
    }
}
