namespace BitzArt.Console;

internal class MainMenu(IConsoleAppNavigationManager navigation) : ConsoleMenuBase
{
    public override string Title => "Main Menu";

    public IConsoleAppNavigationManager Navigation { get; } = navigation;
}
