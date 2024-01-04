using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public class ConsoleApp(ConsoleAppBuilder builder)
{
    public IServiceProvider Services { get; private set; } = builder.Services.BuildServiceProvider();

    public void Run<TConsoleMenu>(CancellationToken cancellationToken = default) where TConsoleMenu : IConsoleMenu
    {
        var consoleMenu = Services.GetRequiredService<TConsoleMenu>();
        consoleMenu.RunAsync().Wait(cancellationToken);
    }
}