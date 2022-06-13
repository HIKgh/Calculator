namespace Calculator.Infrastructure.Services.CalculatorService.Interfaces;

public interface IArithmeticControlModule
{
    public double ExecuteCommand(IArithmeticCommand command);
}