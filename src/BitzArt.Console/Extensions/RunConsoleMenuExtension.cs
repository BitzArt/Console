using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public static class RunConsoleMenuExtension
{
    internal static async Task RunConsoleMenuAsync<TConsoleMenu>(this IServiceProvider serviceProvider)
        where TConsoleMenu : IConsoleMenu
    {
        var menu = serviceProvider.GetRequiredService<TConsoleMenu>();

        AttachApp(menu, serviceProvider);

        await menu.RunAsync();
    }

    internal static async Task RunConsoleMenuAsync(this IServiceProvider serviceProvider, Type menuType)
    {
        if (!menuType.IsAssignableTo(typeof(IConsoleMenu))) throw new ArgumentException($"Menu Type must implement {nameof(IConsoleMenu)}", nameof(menuType));
        
        var menu = (IConsoleMenu)serviceProvider.GetRequiredService(menuType);

        AttachApp(menu, serviceProvider);

        await menu.RunAsync();
    }

    private static void AttachApp(this IConsoleMenu menu, IServiceProvider serviceProvider)
    {
        if (menu is not ConsoleMenu consoleMenu) return;

        var app = serviceProvider.GetService<ConsoleApp>();
        consoleMenu.App = app;
    }
}
