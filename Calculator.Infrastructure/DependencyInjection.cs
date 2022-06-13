using Calculator.Infrastructure.Services.CalculatorService.Implementation;
using Calculator.Infrastructure.Services.CalculatorService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IArithmeticModule, ArithmeticModule>()
            .AddSingleton<IArithmeticControlModule, ArithmeticControlModule>()
            .AddSingleton<IArithmeticCommandFactory<AddArithmeticCommand>, AddArithmeticCommandFactory>()
            .AddSingleton<IArithmeticCommandFactory<SubArithmeticCommand>, SubArithmeticCommandFactory>()
            .AddSingleton<IArithmeticCommandFactory<MulArithmeticCommand>, MulArithmeticCommandFactory>()
            .AddSingleton<IArithmeticCommandFactory<DivArithmeticCommand>, DivArithmeticCommandFactory>()
            .AddSingleton<ICalculatorClient, CalculatorClient>();

        return serviceCollection;
    }
}
