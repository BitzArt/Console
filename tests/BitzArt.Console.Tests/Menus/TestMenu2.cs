using BitzArt.Console;
using Spectre.Console;

namespace BitzArt.Console;

public class TestMenu2 : IConsoleMenu
{
    public Task RunAsync()
    {
        AnsiConsole.WriteLine("Test Menu 2");

        return Task.CompletedTask;
    }
}
