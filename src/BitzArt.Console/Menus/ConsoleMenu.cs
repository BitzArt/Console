using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleMenu
{
    public ConsoleApp? App { get; set; }
    public ConsoleMenu? Parent { get; set; }

    public string? Title { get; internal set; }

    public bool? IsMainMenu { get; internal set; }

    public Task RunAsync()
    {
        Render();
        return Task.CompletedTask;
    }

    protected virtual void Render()
    {
        AnsiConsole.Clear();
        OnBeforeDisplay();
        Display();
        OnDisplayed();
    }

    protected virtual void OnBeforeDisplay()
    {
    }

    protected virtual void Display()
    {
        AnsiConsoleMenu.WriteTitle(Title!);
    }

    protected virtual void OnDisplayed()
    {
    }

    public async Task RunAsync<TConsoleMenu>() where TConsoleMenu : class
    {
        var navigationManager = App!.Services.GetRequiredService<IConsoleAppNavigationManager>();
        await navigationManager.NavigateAsync<TConsoleMenu>();
    }
}
