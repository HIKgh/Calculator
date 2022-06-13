using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class ArithmeticModule : IArithmeticModule
{
    public double Run(char operationCode, double operand1, double operand2)
    {
        double value = 0;
        switch (operationCode)
        {
            case '+':
                value = operand1 + operand2;
                break;
            case '-':
                value = operand1 - operand2;
                break;
            case '*':
                value = operand1 * operand2;
                break;
            case '/':
                value = operand2 != 0.0 ? operand1 / operand2 : 0.0;
                break;
        }

        return value;
    }
}