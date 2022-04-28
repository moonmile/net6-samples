using Grpc.Core;
using GrpcServer;

namespace GrpcServer.Services;

public class CalcService : Calc.CalcBase
{
    private readonly ILogger<CalcService> _logger;
    public CalcService(ILogger<CalcService> logger)
    {
        _logger = logger;
    }

    public override Task<CalcResponse> Add(CalcRequest request, ServerCallContext context)
    {
        int ans = request.X + request.Y;
        var res = new CalcResponse() { Ans = ans };
        return Task.FromResult(res);
    }
}
