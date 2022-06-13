using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class ArithmeticControlModule : IArithmeticControlModule
{
    public double ExecuteCommand(IArithmeticCommand command)
    {
        var result = command.Execute();

        return result;
    }
}