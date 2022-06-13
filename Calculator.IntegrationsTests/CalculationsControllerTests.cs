using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Calculator.Application.Features.Calculations.Commands;
using Calculator.Application.Features.Calculations.Models;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using NUnit.Framework;

namespace Calculator.IntegrationsTests;

public class CalculationsControllerTests
{
    private const double Operand1 = 14;
    private const double Operand2 = 7;
    private static readonly string AddUri = $"api/calculations/{Operand1}/{Operand2}/addition";
    private static readonly string SubUri = $"api/calculations/{Operand1}/{Operand2}/subtraction";
    private static readonly string MulUri = $"api/calculations/{Operand1}/{Operand2}/multiplication";
    private static readonly string DivUri = $"api/calculations/{Operand1}/{Operand2}/division";

    private readonly Mock<IMediator> _mediatorMock = new();
    private HttpClient _httpClient = null!;

    private async Task<(HttpResponseMessage, CalculationResult?)> GetHttpResponseResult(string uri)
    {
        var response = await _httpClient.GetAsync(uri);
        var stringContent = await response.Content.ReadAsStringAsync();
        var content = JsonSerializer.Deserialize<CalculationResult>(stringContent,
            new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        return (response, content);
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var webApplication = new WebApplicationFactory<CalculatorHost>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseTestServer();
                builder.ConfigureServices(_ => _.Replace(ServiceDescriptor.Singleton(_mediatorMock.Object)));
            });
        _httpClient = webApplication.CreateClient();
    }

    [Test]
    public async Task AdditionTest()
    {
        var result = new CalculationResult
        {
            Result = Operand1 + Operand2,
        };
        _mediatorMock
            .Setup(_ => _.Send(It.IsAny<AddArithmeticApiCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
        var (response, content) = await GetHttpResponseResult(AddUri);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(result);
        _mediatorMock.Verify(_ => _.Send(It.IsAny<AddArithmeticApiCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task SubtractionTest()
    {
        var result = new CalculationResult
        {
            Result = Operand1 + Operand2,
        };
        _mediatorMock
            .Setup(_ => _.Send(It.IsAny<SubArithmeticApiCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
        var (response, content) = await GetHttpResponseResult(SubUri);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(result);
        _mediatorMock.Verify(_ => _.Send(It.IsAny<SubArithmeticApiCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task MultiplicationTest()
    {
        var result = new CalculationResult
        {
            Result = Operand1 + Operand2,
        };
        _mediatorMock
            .Setup(_ => _.Send(It.IsAny<MulArithmeticApiCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
        var (response, content) = await GetHttpResponseResult(MulUri);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(result);
        _mediatorMock.Verify(_ => _.Send(It.IsAny<MulArithmeticApiCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DivisionTest()
    {
        var result = new CalculationResult
        {
            Result = Operand1 + Operand2,
        };
        _mediatorMock
            .Setup(_ => _.Send(It.IsAny<DivArithmeticApiCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(result);
        var (response, content) = await GetHttpResponseResult(DivUri);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        content.Should().BeEquivalentTo(result);
        _mediatorMock.Verify(_ => _.Send(It.IsAny<DivArithmeticApiCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}