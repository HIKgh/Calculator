using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Calculator.UnitTests;

public class DivArithmeticCommandFactoryTests
{
    private const double Operand1 = 14;
    private const double Operand2 = 7;
    private readonly Mock<IArithmeticModule> _arithmeticModuleMock = new();
    private IArithmeticCommandFactory<DivArithmeticCommand> _factory = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _factory = new DivArithmeticCommandFactory(_arithmeticModuleMock.Object);
    }

    [Test]
    public void CreateTest()
    {
        var command = _factory.Create(Operand1, Operand2);
        command.Should().BeOfType(typeof(DivArithmeticCommand));
    }
}