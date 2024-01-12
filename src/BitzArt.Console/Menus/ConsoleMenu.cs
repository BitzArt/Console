using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleMenu
{
    public ConsoleApp? App { get; set; }
    public ConsoleMenu? Parent { get; set; }

    public string? Title { get; internal set; }

    public bool? IsMainMenu { get; internal set; }

    public void Run()
    {
        Render();
    }

    internal virtual void Render()
    {
        AnsiConsole.Clear();
        DisplayTitle();

        OnRender();
        Display();
        OnDisplay();
    }

    internal virtual void DisplayTitle()
    {
        AnsiConsoleMenu.WriteTitle(Title!);
        AnsiConsole.WriteLine();
    }

    protected virtual void OnRender()
    {
    }

    internal virtual void Display()
    {
    }

    protected virtual void OnDisplay()
    {
    }

    public void Run<TConsoleMenu>() where TConsoleMenu : class
    {
        var navigationManager = App!.Services.GetRequiredService<IConsoleAppNavigationManager>();
        navigationManager.Navigate<TConsoleMenu>();
    }
}
