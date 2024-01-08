using Spectre.Console;

namespace BitzArt.Console;

public class TestMenu1 : IConsoleMenu
{
    public Task RunAsync()
    {
        AnsiConsole.WriteLine("Test Menu 1");

        return Task.CompletedTask;
    }
}
