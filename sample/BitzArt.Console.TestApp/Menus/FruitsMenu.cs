using Spectre.Console;

namespace BitzArt.Console;

internal class FruitsMenu : ConsoleSelectionMenu
{
    public override string Title => "Fruits";

    public FruitsMenu()
    {
        AddSelection("apple", pauseOnComplete: true);
        AddSelection("pear", pauseOnComplete: true);
        AddSelection("banana", pauseOnComplete: true);
    }

    public override void OnSelection(ConsoleSelectionMenuItem selection)
    {
        AnsiConsole.WriteLine($"You selected '{selection.Name}'");
    }
}
