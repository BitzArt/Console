namespace BitzArt.Console;

public interface IConsoleAppNavigationManager
{
    public void Navigate(Type menuType);
    public void Navigate<T>() where T : class;
    public void NavigateToMainMenu();
}