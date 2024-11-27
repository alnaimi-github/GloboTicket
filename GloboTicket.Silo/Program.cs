using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


try
{
    using IHost host = await StartSiloAsync();
    Console.WriteLine("\n\n Press Enter to terminate...\n\n");
    Console.ReadLine();

    await host.StopAsync();

    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

static async Task<IHost> StartSiloAsync()
{
    var builder = Host
        .CreateDefaultBuilder()
        .UseOrleans((context, silo) =>
        {
            silo
                .UseLocalhostClustering()
                .ConfigureLogging(logging => logging.AddConsole());
        });

    var host = builder.Build();
    await host.StartAsync();

    return host;
}