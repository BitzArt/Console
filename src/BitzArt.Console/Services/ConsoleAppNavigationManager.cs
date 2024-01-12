using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

internal class ConsoleAppNavigationManager(IServiceProvider serviceProvider) : IConsoleAppNavigationManager
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public void NavigateToMainMenu()
    {
        var map = _serviceProvider.GetRequiredService<MenuMap>();
        var mainMenu = map.GetMainMenuItem();
        _serviceProvider.RunConsoleMenuAsync(mainMenu.MenuType);
    }

    public void Navigate<T>() where T : class
    {
        _serviceProvider.RunConsoleMenuAsync<T>();
    }

    public void Navigate(Type menuType)
    {
        _serviceProvider.RunConsoleMenuAsync(menuType);
    }
}
