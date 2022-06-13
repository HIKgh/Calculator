namespace Calculator;

public class EntryPoint
{
    public static async Task Main(string[] args)
    {
        var host = CalculatorHost.CreateHost(args);
        host.ConfigureHost()
            .ConfigureSwaggerService()
            .ConfigureServices();

        await host.RunHost();
    }
}