using Spectre.Console;

namespace BitzArt.Console;

public class ConsoleSelectionMenuItem
{
    public ConsoleSelectionMenuItem(string name, Action? action = null, bool pauseOnComplete = false)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Selection name cannot be empty.", nameof(name));
        }

        Name = name;
        Action = action;
        PauseOnComplete = pauseOnComplete;
    }

    public string Name { get; set; }
    public Action? Action { get; set; }

    public bool IsExit = false;
    public bool PauseOnComplete = false;

    public override string ToString() => Name;

    internal static ConsoleSelectionMenuItem ExitItem => new("Exit")
    {
        IsExit = true
    };

    internal static ConsoleSelectionMenuItem BackItem => new("Back")
    {
        IsExit = true
    };
}
