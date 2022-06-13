namespace Calculator.Application.Features.Calculations.Exceptions;

public class OperandOutOfRangeException : Exception
{
    public OperandOutOfRangeException(string message) : base(message)
    {
    }
}