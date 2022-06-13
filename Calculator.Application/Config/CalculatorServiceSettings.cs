namespace Calculator.Application.Config;

public class CalculatorServiceSettings
{
    public double OperandMinValue { get; set; } = -10_000_000.0;
    
    public double OperandMaxValue { get; set; } = 10_000_000.0;
}