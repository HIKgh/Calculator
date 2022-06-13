using Calculator.Application.Features.Calculations.Commands;
using FluentValidation;

namespace Calculator.Application.Features.Calculations.Validation;

public class DivideByZeroValidator : AbstractValidator<DivArithmeticApiCommand>
{
    public DivideByZeroValidator()
    {
        RuleFor(request => request)
            .Must(IsValidOperands)
            .OnAnyFailure(error
                => throw new DivideByZeroException("Divide by zero"));
    }

    private static bool IsValidOperands(DivArithmeticApiCommand command)
    {
        return command.Operand2 != 0.0;
    }
}