using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.Console;

public static class RunConsoleMenuExtension
{
    public static async Task RunConsoleMenuAsync<TConsoleMenu>(this IServiceProvider serviceProvider)
        where TConsoleMenu : IConsoleMenu
    {
        var tool = serviceProvider.GetRequiredService<TConsoleMenu>();

        await tool.RunAsync();
    }

    public static async Task RunConsoleMenuAsync(this IServiceProvider serviceProvider, Type menuType)
    {
        if (!menuType.IsAssignableTo(typeof(IConsoleMenu))) throw new ArgumentException($"Menu Type must implement {nameof(IConsoleMenu)}", nameof(menuType));
        
        var tool = (IConsoleMenu)serviceProvider.GetRequiredService(menuType);

        await tool.RunAsync();
    }
}
