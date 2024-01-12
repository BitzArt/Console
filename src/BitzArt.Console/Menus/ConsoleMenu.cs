using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleMenu
{
    public ConsoleApp? App { get; set; }
    public ConsoleMenu? Parent { get; set; }

    public string? Title { get; internal set; }

    public bool? IsMainMenu { get; internal set; }

    public async Task RunAsync()
    {
        await RenderAsync();
    }

    internal virtual async Task RenderAsync()
    {
        AnsiConsole.Clear();
        DisplayTitle();

        OnRender();
        await OnRenderAsync();

        await DisplayAsync();

        await OnDisplayAsync();
        OnDisplay();
    }

    internal virtual void DisplayTitle()
    {
        AnsiConsoleMenu.WriteTitle(Title!);
        AnsiConsole.WriteLine();
    }

    protected virtual Task OnRenderAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual void OnRender()
    {
    }

    internal virtual Task DisplayAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual Task OnDisplayAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual void OnDisplay()
    {
    }

    public async Task RunAsync<TConsoleMenu>() where TConsoleMenu : class
    {
        var navigationManager = App!.Services.GetRequiredService<IConsoleAppNavigationManager>();
        await navigationManager.NavigateAsync<TConsoleMenu>();
    }
}
