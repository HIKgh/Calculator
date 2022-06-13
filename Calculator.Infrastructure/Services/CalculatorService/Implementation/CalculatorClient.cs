using Calculator.Infrastructure.Services.CalculatorService.Interfaces;

namespace Calculator.Infrastructure.Services.CalculatorService.Implementation;

public class CalculatorClient : ICalculatorClient
{
    private readonly IArithmeticControlModule _arithmeticControlModule;

    private readonly IArithmeticCommandFactory<AddArithmeticCommand> _addFactory;

    private readonly IArithmeticCommandFactory<SubArithmeticCommand> _subFactory;

    private readonly IArithmeticCommandFactory<MulArithmeticCommand> _mulFactory;

    private readonly IArithmeticCommandFactory<DivArithmeticCommand> _divFactory;

    public CalculatorClient(IArithmeticControlModule arithmeticControlModule,
        IArithmeticCommandFactory<AddArithmeticCommand> addFactory,
        IArithmeticCommandFactory<SubArithmeticCommand> subFactory,
        IArithmeticCommandFactory<MulArithmeticCommand> mulFactory,
        IArithmeticCommandFactory<DivArithmeticCommand> divFactory)
    {
        _arithmeticControlModule = arithmeticControlModule;
        _addFactory = addFactory;
        _subFactory = subFactory;
        _mulFactory = mulFactory;
        _divFactory = divFactory;
    }

    private double Run(IArithmeticCommand command)
    {
        var result = _arithmeticControlModule.ExecuteCommand(command);

        return result;
    }

    public double Add(double operand1, double operand2)
    {
        var result = Run(_addFactory.Create(operand1, operand2));

        return result;
    }

    public double Sub(double operand1, double operand2)
    {
        var result = Run(_subFactory.Create(operand1, operand2));

        return result;
    }

    public double Mul(double operand1, double operand2)
    {
        var result = Run(_mulFactory.Create(operand1, operand2));

        return result;
    }

    public double Div(double operand1, double operand2)
    {
        var result = Run(_divFactory.Create(operand1, operand2));
        return result;
    }
}