using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Calculator.UnitTests;

public class ArithmeticControlModuleTests
{
    private const double Operand1 = 14;
    private const double Operand2 = 7;
    private readonly Mock<IArithmeticCommand> _addCommand = new();
    private readonly Mock<IArithmeticCommand> _subCommand = new();
    private readonly Mock<IArithmeticCommand> _mulCommand = new();
    private readonly Mock<IArithmeticCommand> _divCommand = new();
    private IArithmeticControlModule _arithmeticControlModule = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _addCommand.Setup(_ => _.Execute()).Returns(Operand1 + Operand2);
        _subCommand.Setup(_ => _.Execute()).Returns(Operand1 - Operand2);
        _mulCommand.Setup(_ => _.Execute()).Returns(Operand1 * Operand2);
        _divCommand.Setup(_ => _.Execute()).Returns(Operand1 / Operand2);
        _arithmeticControlModule = new ArithmeticControlModule();
    }

    [Test]
    public void ExecuteCommandTest()
    {
        _arithmeticControlModule.ExecuteCommand(_addCommand.Object).Should().Be(Operand1 + Operand2);
        _arithmeticControlModule.ExecuteCommand(_subCommand.Object).Should().Be(Operand1 - Operand2);
        _arithmeticControlModule.ExecuteCommand(_mulCommand.Object).Should().Be(Operand1 * Operand2);
        _arithmeticControlModule.ExecuteCommand(_divCommand.Object).Should().Be(Operand1 / Operand2);
    }
}