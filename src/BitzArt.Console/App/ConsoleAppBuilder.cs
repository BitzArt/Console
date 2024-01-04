using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public class ConsoleAppBuilder
{
    public IServiceCollection Services { get; private set; }

    public ConsoleAppBuilder()
    {
        Services = new ServiceCollection();

        Services.AddSingleton<IConsoleAppNavigationManager, ConsoleAppNavigationManager>();
    }

    public ConsoleApp Build() => new(this);
}
