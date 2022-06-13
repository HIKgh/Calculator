namespace Calculator.Infrastructure.Services.CalculatorService.Interfaces;

public interface ICalculatorClient
{
    public double Add(double operand1, double operand2);

    public double Sub(double operand1, double operand2);

    public double Mul(double operand1, double operand2);

    public double Div(double operand1, double operand2);
}