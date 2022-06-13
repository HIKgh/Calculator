using Calculator.Application.Features.Calculations.Commands;
using Calculator.Application.Features.Calculations.Models;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using MediatR;

namespace Calculator.Application.Features.Calculations.Handlers;

public class DivArithmeticApiCommandHandler : IRequestHandler<DivArithmeticApiCommand, CalculationResult>
{
    private readonly ICalculatorClient _calculatorClient;

    public DivArithmeticApiCommandHandler(ICalculatorClient calculatorClient)
    {
        _calculatorClient = calculatorClient;
    }

    public Task<CalculationResult> Handle(DivArithmeticApiCommand request, CancellationToken cancellationToken)
    {
        var result = _calculatorClient.Div(request.Operand1, request.Operand2);

        return Task.FromResult(new CalculationResult { Result = result });
    }
}