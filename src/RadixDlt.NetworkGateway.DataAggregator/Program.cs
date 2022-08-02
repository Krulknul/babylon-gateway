namespace RadixDlt.NetworkGateway.DataAggregator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        using var host = CreateHostBuilder(args).Build();

        await host.RunAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .ConfigureKestrel(o =>
                    {
                        o.AddServerHeader = false;
                    })
                    .UseStartup<DataAggregatorStartup>();
            });
}
