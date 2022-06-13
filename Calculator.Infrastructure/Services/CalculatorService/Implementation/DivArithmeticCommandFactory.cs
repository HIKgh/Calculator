using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class DivArithmeticCommandFactory : IArithmeticCommandFactory<DivArithmeticCommand>
{
    private readonly IArithmeticModule _arithmeticModule;

    public DivArithmeticCommandFactory(IArithmeticModule arithmeticModule)
    {
        _arithmeticModule = arithmeticModule;
    }

    public DivArithmeticCommand Create(double operand1, double operand2)
    {
        return new DivArithmeticCommand(_arithmeticModule, operand1, operand2);
    }
}