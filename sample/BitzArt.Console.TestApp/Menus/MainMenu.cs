namespace BitzArt.Console;

internal class MainMenu : ConsoleSelectionMenu
{
    public override string Title => "Main Menu";
    protected override bool IsMainMenu => true;

    public MainMenu()
    {
        AddSubmenu<FruitsMenu>("Fruits");
        AddSubmenu<VeggiesMenu>("Veggies");
    }
}
