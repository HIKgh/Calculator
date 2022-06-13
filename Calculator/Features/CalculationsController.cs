using Calculator.Application.Features.Calculations.Commands;
using Calculator.Application.Features.Calculations.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Features;

[ApiController]
[Route("api/calculations")]
public class CalculationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CalculationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{operand1}/{operand2}/addition")]
    public async Task<CalculationResult> Addition(
        [FromRoute(Name = "operand1")] double operand1,
        [FromRoute(Name = "operand2")] double operand2)
    {
        var command = new AddArithmeticApiCommand(operand1, operand2);

        return await _mediator.Send(command);
    }

    [HttpGet("{operand1}/{operand2}/subtraction")]
    public async Task<CalculationResult> Subtraction(
        [FromRoute(Name = "operand1")] double operand1,
        [FromRoute(Name = "operand2")] double operand2)
    {
        var command = new SubArithmeticApiCommand(operand1, operand2);

        return await _mediator.Send(command);
    }

    [HttpGet("{operand1}/{operand2}/multiplication")]
    public async Task<CalculationResult> Multiplication(
        [FromRoute(Name = "operand1")] double operand1,
        [FromRoute(Name = "operand2")] double operand2)
    {
        var command = new MulArithmeticApiCommand(operand1, operand2);

        return await _mediator.Send(command);
    }

    [HttpGet("{operand1}/{operand2}/division")]
    public async Task<CalculationResult> Division(
        [FromRoute(Name = "operand1")] double operand1,
        [FromRoute(Name = "operand2")] double operand2)
    {
        var command = new DivArithmeticApiCommand(operand1, operand2);

        return await _mediator.Send(command);
    }
}