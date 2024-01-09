using Microsoft.Extensions.DependencyInjection;
using System;

namespace BitzArt.Console;

public static class RunConsoleMenuExtension
{
    internal static async Task RunConsoleMenuAsync<TConsoleMenu>(this IServiceProvider serviceProvider)
        where TConsoleMenu : class
    {
        var menu = serviceProvider.GetRequiredService<TConsoleMenu>();

        if (menu is not ConsoleMenu consoleMenu) return;

        consoleMenu.Populate(serviceProvider);

        await consoleMenu.RunAsync();
    }

    internal static async Task RunConsoleMenuAsync(this IServiceProvider serviceProvider, Type menuType)
    {
        var menu = serviceProvider.GetRequiredService(menuType);

        if (menu is not ConsoleMenu consoleMenu) return;

        consoleMenu.Populate(serviceProvider);

        await consoleMenu.RunAsync();
    }

    private static void Populate(this ConsoleMenu menu, IServiceProvider serviceProvider)
    {
        var app = serviceProvider.GetService<ConsoleApp>();
        menu.App = app;

        var appMenuAttribute = menu.GetType().GetAppMenuAttribute();
        menu.Title = appMenuAttribute!.GetTitle();
        menu.IsMainMenu = appMenuAttribute.IsMain;

        menu.PopulateSelectionFromMethods();
    }

    private static void PopulateSelectionFromMethods(this ConsoleMenu consoleMenu)
    {
        if (consoleMenu is not ConsoleSelectionMenu selectionMenu) return;

        var selections = consoleMenu.GetType().GetSelectionMethods();
        foreach (var selection in selections)
        {
            selectionMenu.AddSelection(selection.Name, () => selection.Method.Invoke(selectionMenu, null), selection.PauseOnComplete);
        }
    }
}
