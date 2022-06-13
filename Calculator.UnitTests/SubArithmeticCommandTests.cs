using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Calculator.UnitTests;

public class SubArithmeticCommandTests
{
    private const char OperationCode = '-';
    private const double Operand1 = 4;
    private const double Operand2 = 1;
    private readonly Mock<IArithmeticModule> _arithmeticModuleMock = new();
    private SubArithmeticCommand _command = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _arithmeticModuleMock.Setup(_ => _.Run(OperationCode, Operand1, Operand2))
            .Returns(Operand1 - Operand2);
        _command = new SubArithmeticCommand(_arithmeticModuleMock.Object, Operand1, Operand2);
    }

    [Test]
    public void ExecuteTest()
    {
        var result = _command.Execute();
        result.Should().Be(Operand1 - Operand2);
    }
}