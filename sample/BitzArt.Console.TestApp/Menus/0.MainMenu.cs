namespace BitzArt.Console;

internal class MainMenu : ConsoleSelectionMenu
{
    public override string Title => "Main Menu";
    protected override bool IsMainMenu => true;

    public MainMenu()
    {
        AddSubmenu<FruitsMenu>("1. Fruits");
        AddSubmenu<VeggiesMenu>("2. Veggies");
    }
}
