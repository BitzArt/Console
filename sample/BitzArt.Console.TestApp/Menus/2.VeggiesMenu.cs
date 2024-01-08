using Spectre.Console;

namespace BitzArt.Console;

internal class VeggiesMenu : ConsoleSelectionMenu
{
    public override string Title => "Veggies";

    public VeggyOptions _options;

    private bool _focusOnPotato = false;

    public VeggiesMenu(VeggyOptions options)
    {
        AddSelection("tomato", pauseOnComplete: true);
        AddSelection("cucumber", pauseOnComplete: true);
        AddSelection("is potato a vegetable?", () => _focusOnPotato = true, pauseOnComplete: true);
        _options = options;
    }

    public override void OnBeforeSelectionInvoke(ConsoleSelectionMenuItem selection)
    {
        _focusOnPotato = false;
        AnsiConsole.WriteLine($"You selected '{selection.Name}'");
    }

    public override void OnSelection(ConsoleSelectionMenuItem selection)
    {
        if (_focusOnPotato)
        {
            var possibleNegation = _options.IsPotatoAVegetable ? "" : "not ";
            var text = $"Application settings say that potato is {possibleNegation}a vegetable.";
            AnsiConsole.WriteLine(text);
            return;
        }
    }
}
