using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class SubArithmeticCommandFactory : IArithmeticCommandFactory<SubArithmeticCommand>
{
    private readonly IArithmeticModule _arithmeticModule;

    public SubArithmeticCommandFactory(IArithmeticModule arithmeticModule)
    {
        _arithmeticModule = arithmeticModule;
    }

    public SubArithmeticCommand Create(double operand1, double operand2)
    {
        return new SubArithmeticCommand(_arithmeticModule, operand1, operand2);
    }
}