using Calculator.Application.Features.Calculations.Commands;
using Calculator.Application.Features.Calculations.Models;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using MediatR;

namespace Calculator.Application.Features.Calculations.Handlers;

public class SubArithmeticApiCommandHandler : IRequestHandler<SubArithmeticApiCommand, CalculationResult>
{
    private readonly ICalculatorClient _calculatorClient;

    public SubArithmeticApiCommandHandler(ICalculatorClient calculatorClient)
    {
        _calculatorClient = calculatorClient;
    }

    public Task<CalculationResult> Handle(SubArithmeticApiCommand request, CancellationToken cancellationToken)
    {
        var result = _calculatorClient.Sub(request.Operand1, request.Operand2);

        return Task.FromResult(new CalculationResult { Result = result });
    }
}