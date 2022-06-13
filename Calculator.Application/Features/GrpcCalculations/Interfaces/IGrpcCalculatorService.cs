using Calc;
using Grpc.Core;

namespace Calculator.Application.Features.GrpcCalculations.Interfaces;

public interface IGrpcCalculatorService
{
    public Task<CalculationResult> Addition(ArithmeticCommandRequest request, ServerCallContext context);

    public Task<CalculationResult> Subtraction(ArithmeticCommandRequest request, ServerCallContext context);

    public Task<CalculationResult> Multiplication(ArithmeticCommandRequest request, ServerCallContext context);

    public Task<CalculationResult> Division(ArithmeticCommandRequest request, ServerCallContext context);
}