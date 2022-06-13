namespace Calculator.Infrastructure.Services.CalculatorService.Interfaces;

public interface IArithmeticModule
{
    public double Run(char operationCode, double operand1, double operand2);
}