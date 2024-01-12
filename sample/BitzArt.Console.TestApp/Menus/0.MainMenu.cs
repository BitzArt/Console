namespace BitzArt.Console;

[AppMenu("Main Menu", IsMain = true)]
internal class MainMenu : ConsoleSelectionMenu
{
    [MenuSelectionItem("Veggies")]
    public void NavigateToVeggiesMenu()
    {
        Run<VeggiesMenu>();
    }
}
