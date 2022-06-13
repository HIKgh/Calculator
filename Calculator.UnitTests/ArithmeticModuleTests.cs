using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Calculator.UnitTests;

[TestFixture]
public class ArithmeticModuleTests
{
    private IArithmeticModule _arithmeticModule = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _arithmeticModule = new ArithmeticModule();
    }

    [TestCase('+',14, 7, 21)]
    [TestCase('-', 4, 1, 3)]
    [TestCase('*', 5, 6, 30)]
    [TestCase('/', -20, 2, -10)]
    [TestCase('/', 10, 0, 0)]
    public void RunOperationTest(char operationCode, double operand1, double operand2, double result)
    {
        var value = _arithmeticModule.Run(operationCode, operand1, operand2);
        value.Should().Be(result);
    }
}