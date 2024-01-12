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

    public void Run()
    {
        var navigationManager = Services.GetRequiredService<IConsoleAppNavigationManager>();
        navigationManager.NavigateToMainMenu();
    }

    public void Run(Type mainMenuType)
    {
        var navigationManager = Services.GetRequiredService<IConsoleAppNavigationManager>();
        navigationManager.Navigate(mainMenuType);
    }

    public void Run<TConsoleMenu>() where TConsoleMenu : class
    {
        var navigationManager = Services.GetRequiredService<IConsoleAppNavigationManager>();
        navigationManager.Navigate<TConsoleMenu>();
    }

    public static IConsoleAppBuilder CreateBuilder()
    {
        return new ConsoleAppBuilder();
    }
}