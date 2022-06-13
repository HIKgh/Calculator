using System.Reflection;
using Calculator.Application.Common.Behaviors;
using Calculator.Application.Config;
using Calculator.Application.Features.Calculations.Commands;
using Calculator.Application.Features.Calculations.Validation;
using Calculator.Application.Features.GrpcCalculations.Implementation;
using Calculator.Application.Features.GrpcCalculations.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(config => config.AsSingleton(), Assembly.GetExecutingAssembly());
        serviceCollection.Configure<CalculatorServiceSettings>(configuration.GetSection(nameof(CalculatorServiceSettings)));
        serviceCollection.AddTransient(typeof(IValidator<>), typeof(OperandsValidator<>));
        serviceCollection.AddTransient(typeof(IValidator<DivArithmeticApiCommand>), typeof(DivideByZeroValidator));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationsBehavior<,>));
        serviceCollection.AddScoped<IGrpcCalculatorService, GrpcCalculatorService>();

        return serviceCollection;
    }
}