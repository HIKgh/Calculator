using Calculator.Application.Config;
using Calculator.Application.Features.Calculations.Exceptions;
using Calculator.Application.Features.Calculations.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Calculator.Application.Features.Calculations.Validation;

public class OperandsValidator<TRequest> : AbstractValidator<TRequest> where TRequest: IArithmeticApiCommandOperands
{
    private CalculatorServiceSettings _settings;

    public OperandsValidator(IOptionsMonitor<CalculatorServiceSettings> optionsMonitor)
    {
        _settings = optionsMonitor.CurrentValue;
        optionsMonitor.OnChange(settings => _settings = settings);

        RuleFor(request => request)
            .Must(IsValidOperands)
            .OnAnyFailure(error
                => throw new OperandOutOfRangeException($"Operands {error.Operand1}:{error.Operand2} are out of range {_settings.OperandMinValue}:{_settings.OperandMaxValue}"));
    }

    private bool IsValidOperands(TRequest request)
    {
        return IsValidOperand(request.Operand1) && IsValidOperand(request.Operand2);
    }

    private bool IsValidOperand(double operand)
    {
        return operand >= _settings.OperandMinValue && operand <= _settings.OperandMaxValue;
    }
}