using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class AddArithmeticCommandFactory : IArithmeticCommandFactory<AddArithmeticCommand>
{
    private readonly IArithmeticModule _arithmeticModule;

    public AddArithmeticCommandFactory(IArithmeticModule arithmeticModule)
    {
        _arithmeticModule = arithmeticModule;
    }

    public AddArithmeticCommand Create(double operand1, double operand2)
    {
        return new AddArithmeticCommand(_arithmeticModule, operand1, operand2);
    }
}