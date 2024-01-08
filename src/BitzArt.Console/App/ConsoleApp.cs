using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public class ConsoleApp
{
    public IServiceProvider Services { get; private set; }

    public ConsoleApp(IConsoleAppBuilder builder)
    {
        builder.Services.AddSingleton(this);
        Services = builder.Services.BuildServiceProvider();
    }

    public void Run<TConsoleMenu>(CancellationToken cancellationToken = default) where TConsoleMenu : IConsoleMenu
    {
        var navigationManager = Services.GetRequiredService<IConsoleAppNavigationManager>();
        navigationManager.NavigateAsync<TConsoleMenu>().Wait(cancellationToken);
    }

    public static IConsoleAppBuilder CreateBuilder()
    {
        return new ConsoleAppBuilder();
    }
}