namespace BitzArt.Console;

public interface IConsoleAppNavigationManager
{
    Task NavigateAsync(Type menuType);
    Task NavigateAsync<T>() where T : class;
    Task NavigateToMainMenuAsync();
}