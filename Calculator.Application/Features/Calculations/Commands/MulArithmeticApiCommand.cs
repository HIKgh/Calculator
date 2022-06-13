using Calculator.Application.Features.Calculations.Interfaces;
using Calculator.Application.Features.Calculations.Models;
using MediatR;

namespace Calculator.Application.Features.Calculations.Commands;

public class MulArithmeticApiCommand : IRequest<CalculationResult>, IArithmeticApiCommandOperands
{
    public double Operand1 { get; }

    public double Operand2 { get; }

    public MulArithmeticApiCommand(double operand1, double operand2)
    {
        Operand1 = operand1;
        Operand2 = operand2;
    }
}