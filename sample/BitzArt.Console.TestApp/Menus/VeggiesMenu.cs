using Spectre.Console;

namespace BitzArt.Console;

internal class VeggiesMenu : ConsoleSelectionMenu
{
    public override string Title => "Veggies";

    private bool _selectedPotato = false;

    public VeggiesMenu()
    {
        AddSelection("tomato", pauseOnComplete: true);
        AddSelection("cucumber", pauseOnComplete: true);
        AddSelection("is potato a vegetable?", () => _selectedPotato = true, pauseOnComplete: true);
    }

    public override void OnSelection(ConsoleSelectionMenuItem selection)
    {
        AnsiConsole.WriteLine($"You selected '{selection.Name}'");
    }

    public override void OnSelectionInvoked(ConsoleSelectionMenuItem selection)
    {
        if (_selectedPotato)
        {
            AnsiConsole.WriteLine($"Potato is a vegetable.");
            return;
        }
    }
}
