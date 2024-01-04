namespace BitzArt.Console;

internal class ConsoleAppNavigationManager(IServiceProvider serviceProvider) : IConsoleAppNavigationManager
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task NavigateAsync<T>() where T : IConsoleMenu
    {
        await _serviceProvider.RunConsoleMenuAsync<T>();
    }

    public async Task NavigateAsync(Type menuType)
    {
        await _serviceProvider.RunConsoleMenuAsync(menuType);
    }
}
