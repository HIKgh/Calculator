using Calculator.Application;
using Calculator.Application.Features.GrpcCalculations.Implementation;
using Calculator.Infrastructure;
using Calculator.Middleware.CustomExceptionHandler.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Serilog;

namespace Calculator;

public class CalculatorHost
{
    private const string ConfigurationFileName = "appsettings.json";

    private readonly WebApplicationBuilder _builder;

    private CalculatorHost(string[] args)
    {
        _builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            ApplicationName = typeof(EntryPoint).Assembly.FullName,
            ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
        });
    }

    public static CalculatorHost CreateHost(string[] args)
    {
        return new CalculatorHost(args);
    }

    public CalculatorHost ConfigureServices()
    {
        _builder.Services.AddControllers();
        _builder.Services.AddGrpc();
        _builder.Services
            .AddInfrastructure()
            .AddApplication(_builder.Configuration);

        return this;
    }

    public CalculatorHost ConfigureSwaggerService()
    {
        _builder.Services.AddEndpointsApiExplorer();
        _builder.Services.AddSwaggerGen();

        return this;
    }

    public CalculatorHost ConfigureHost()
    {
        _builder.Host.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddJsonFile(ConfigurationFileName, true, true);
            })
            .UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });

        _builder.WebHost.UseKestrel(options =>
        {
            options.ListenAnyIP(_builder.Configuration.GetValue<int>("CalculatorApiSettings:RestApiPort"),
                listenOptions => listenOptions.Protocols = HttpProtocols.Http1);
            options.ListenAnyIP(_builder.Configuration.GetValue<int>("CalculatorApiSettings:GrpcApiPort"),
                listenOptions => listenOptions.Protocols = HttpProtocols.Http2);
        });

        return this;
    }

    public async Task RunHost()
    {
        var app = _builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCustomExceptionHandler();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGrpcService<GrpcCalculatorService>();
        });

        await app.RunAsync();
    }
}