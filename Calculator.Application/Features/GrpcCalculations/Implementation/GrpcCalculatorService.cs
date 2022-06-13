using Calc;
using Calculator.Application.Features.GrpcCalculations.Interfaces;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using Grpc.Core;

namespace Calculator.Application.Features.GrpcCalculations.Implementation;

public class GrpcCalculatorService : GrpcCalculator.GrpcCalculatorBase, IGrpcCalculatorService
{
    private readonly ICalculatorClient _client;

    public GrpcCalculatorService(ICalculatorClient client)
    {
        _client = client;
    }

    public override async Task<CalculationResult> Addition(ArithmeticCommandRequest request,
        ServerCallContext context)
    {
        var result = _client.Add(request.Operand1, request.Operand2);

        return await Task.FromResult(new CalculationResult { Result = result });
    }

    public override async Task<CalculationResult> Subtraction(ArithmeticCommandRequest request,
        ServerCallContext context)
    {
        var result = _client.Sub(request.Operand1, request.Operand2);

        return await Task.FromResult(new CalculationResult { Result = result });
    }

    public override async Task<CalculationResult> Multiplication(ArithmeticCommandRequest request,
        ServerCallContext context)
    {
        var result = _client.Mul(request.Operand1, request.Operand2);

        return await Task.FromResult(new CalculationResult { Result = result });
    }

    public override async Task<CalculationResult> Division(ArithmeticCommandRequest request,
        ServerCallContext context)
    {
        var result = _client.Div(request.Operand1, request.Operand2);

        return await Task.FromResult(new CalculationResult { Result = result });
    }
}