namespace BitzArt.Console;

public class ConsoleSelectionMenuItem(string title, Action action)
{
    public string Title { get; set; } = title;
    public Action Action { get; set; } = action;
}
