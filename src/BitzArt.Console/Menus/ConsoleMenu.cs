using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleMenu : IConsoleMenu
{
    public ConsoleApp? App { get; set; }

    public virtual string Title => "Menu";

    public Task RunAsync()
    {
        Render();
        return Task.CompletedTask;
    }

    public virtual void Render()
    {
        AnsiConsole.Clear();
        AnsiConsoleMenu.WriteTitle(Title);
    }

    public async Task RunAsync<TConsoleMenu>() where TConsoleMenu : IConsoleMenu
    {
        var navigationManager = App!.Services.GetRequiredService<IConsoleAppNavigationManager>();
        await navigationManager.NavigateAsync<TConsoleMenu>();
    }
}
