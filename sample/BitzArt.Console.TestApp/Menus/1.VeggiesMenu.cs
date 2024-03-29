﻿using Spectre.Console;

namespace BitzArt.Console;

[AppMenu("Veggies")]
internal class VeggiesMenu(VeggyOptions options) : ConsoleSelectionMenu
{
    private bool _focusOnPotato = false;

    [MenuSelectionItem("Tomato")]
    public static void Tomato()
    {
    }

    [MenuSelectionItem("Cucumber")]
    public static void Cucumber()
    {
    }

    [MenuSelectionItem("Potato")]
    public void Potato()
    {
        _focusOnPotato = true;
    }

    protected override void OnSelection(ConsoleSelectionMenuItem selection)
    {
        _focusOnPotato = false;
    }

    protected override void OnSelectionInvoked(ConsoleSelectionMenuItem selection)
    {
        AnsiConsole.WriteLine($"You selected '{selection.Name}'");

        if (_focusOnPotato)
        {
            var possibleNegation = options.IsPotatoAVegetable ? "" : "not ";
            var text = $"Application settings say that potato is {possibleNegation}a vegetable.";
            AnsiConsole.WriteLine(text);
        }

        Pause();
    }
}
