using Calculator.Application;
using Calculator.Infrastructure;
using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.Extensions.Hosting;

namespace Calculator.IntegrationsTests;

public class CalculatorClientTests
{
    private const double Operand1 = 14;
    private const double Operand2 = 7;
    private IArithmeticControlModule _arithmeticControlModule = null!;
    private IArithmeticCommandFactory<AddArithmeticCommand> _addFactory = null!;
    private IArithmeticCommandFactory<SubArithmeticCommand> _subFactory = null!;
    private IArithmeticCommandFactory<MulArithmeticCommand> _mulFactory = null!;
    private IArithmeticCommandFactory<DivArithmeticCommand> _divFactory = null!;
    private CalculatorClient _calculatorClient = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, collection) =>
            {
                collection.AddInfrastructure();
                collection.AddApplication(config);
            })
            .Build();

        _arithmeticControlModule = host.Services.GetRequiredService<IArithmeticControlModule>();
        _addFactory = host.Services.GetRequiredService<IArithmeticCommandFactory<AddArithmeticCommand>>();
        _subFactory = host.Services.GetRequiredService<IArithmeticCommandFactory<SubArithmeticCommand>>();
        _mulFactory = host.Services.GetRequiredService<IArithmeticCommandFactory<MulArithmeticCommand>>();
        _divFactory = host.Services.GetRequiredService<IArithmeticCommandFactory<DivArithmeticCommand>>();
        _calculatorClient = new CalculatorClient(_arithmeticControlModule,
            _addFactory, _subFactory, _mulFactory, _divFactory);
    }

    [Test]
    public void AddTest()
    {
        var result = _calculatorClient.Add(Operand1, Operand2);
        result.Should().Be(Operand1 + Operand2);
    }

    [Test]
    public void SubTest()
    {
        var result = _calculatorClient.Sub(Operand1, Operand2);
        result.Should().Be(Operand1 - Operand2);
    }

    [Test]
    public void MulTest()
    {
        var result = _calculatorClient.Mul(Operand1, Operand2);
        result.Should().Be(Operand1 * Operand2);
    }

    [Test]
    public void DivTest()
    {
        var result = _calculatorClient.Div(Operand1, Operand2);
        result.Should().Be(Operand1 / Operand2);
    }
}