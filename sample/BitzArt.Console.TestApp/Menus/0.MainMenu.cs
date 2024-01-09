namespace BitzArt.Console;

[AppMenu("Main Menu", IsMain = true)]
internal class MainMenu : ConsoleSelectionMenu
{
    [MenuSelectionItem("Veggies")]
    public async Task SubmenuVeggiesAsync()
    {
        await RunAsync<VeggiesMenu>();
    }
}
