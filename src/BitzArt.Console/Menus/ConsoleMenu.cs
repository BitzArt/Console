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

    internal virtual void Render()
    {
        AnsiConsole.Clear();
        DisplayTitle();
        OnBeforeDisplay();
        Display();
        OnDisplayed();
    }

    internal virtual void DisplayTitle()
    {
        AnsiConsoleMenu.WriteTitle(Title!);
        AnsiConsole.WriteLine();
    }

    protected virtual void OnBeforeDisplay()
    {
    }

    internal virtual void Display()
    {
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
