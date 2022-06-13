using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class SubArithmeticCommand : IArithmeticCommand
{
    private readonly double _operand1;

    private readonly double _operand2;

    private readonly IArithmeticModule _module;

    public SubArithmeticCommand(IArithmeticModule module, double operand1, double operand2)
    {
        _module = module;
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public double Execute()
    {
        return _module.Run('-', _operand1, _operand2);
    }
}