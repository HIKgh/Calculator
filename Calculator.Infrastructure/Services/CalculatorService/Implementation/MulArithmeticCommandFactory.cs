using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class MulArithmeticCommandFactory : IArithmeticCommandFactory<MulArithmeticCommand>
{
    private readonly IArithmeticModule _arithmeticModule;

    public MulArithmeticCommandFactory(IArithmeticModule arithmeticModule)
    {
        _arithmeticModule = arithmeticModule;
    }

    public MulArithmeticCommand Create(double operand1, double operand2)
    {
        return new MulArithmeticCommand(_arithmeticModule, operand1, operand2);
    }
}