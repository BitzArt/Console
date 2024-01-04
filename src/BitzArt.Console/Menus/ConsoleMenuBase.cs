using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleMenuBase : IConsoleMenu
{
    public virtual string Title => "Menu";

    public async Task RunAsync()
    {
        Render();

        OnRendered();
        await OnRenderedAsync();
    }

    public virtual void Render()
    {
        AnsiConsole.Clear();
        AnsiConsoleMenu.WriteTitle(Title);
    }

    public virtual void OnRendered()
    {

    }

    public virtual Task OnRenderedAsync()
    {
        return Task.CompletedTask;
    }
}
