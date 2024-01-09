using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

internal class ConsoleAppNavigationManager(IServiceProvider serviceProvider) : IConsoleAppNavigationManager
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task NavigateToMainMenuAsync()
    {
        var map = _serviceProvider.GetRequiredService<MenuMap>();
        var mainMenu = map.GetMainMenuItem();
        await _serviceProvider.RunConsoleMenuAsync(mainMenu.MenuType);
    }

    public async Task NavigateAsync<T>() where T : class
    {
        await _serviceProvider.RunConsoleMenuAsync<T>();
    }

    public async Task NavigateAsync(Type menuType)
    {
        await _serviceProvider.RunConsoleMenuAsync(menuType);
    }
}
