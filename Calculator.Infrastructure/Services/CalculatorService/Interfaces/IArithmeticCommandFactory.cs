namespace Calculator.Infrastructure.Services.CalculatorService.Interfaces;

public interface IArithmeticCommandFactory<out T> where T : IArithmeticCommand
{
    T Create(double operand1, double operand2);
}