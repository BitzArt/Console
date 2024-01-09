using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

internal class ConsoleAppBuilder : IConsoleAppBuilder
{
    public IServiceCollection Services { get; private set; }
    public IConfiguration Configuration { get; private set; }

    public MenuMap MenuMap { get; private set; }

    public ConsoleAppBuilder()
    {
        Services = new ServiceCollection();

        Services.AddSingleton<IConsoleAppNavigationManager, ConsoleAppNavigationManager>();

        MenuMap = new MenuMap();
        Services.AddSingleton(MenuMap);

        Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }

    public ConsoleApp Build()
    {
        return new ConsoleApp(this);
    }
}
