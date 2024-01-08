using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleSelectionMenu : ConsoleMenu
{
    /// <summary>
    /// Identifies whether this is a main menu of the app or not.
    /// </summary>
    protected virtual bool IsMainMenu => false;

    public override string Title => "Selection Menu";

    protected virtual List<ConsoleSelectionMenuItem> SelectionItems { get; set; } = [];

    public void AddSubmenu<TMenu>(string? selectionName = null)
        where TMenu : IConsoleMenu
    {
        selectionName ??= typeof(TMenu).Name;
        AddSelection(selectionName, async () => await RunAsync<TMenu>());
    }

    public void AddSelection(string name, Action? action = null, bool pauseOnComplete = false)
    {
        SelectionItems.Add(new ConsoleSelectionMenuItem(name, action, pauseOnComplete));
    }

    public override void Render()
    {
        AnsiConsole.Clear();

        var selectionPrompt = new SelectionPrompt<ConsoleSelectionMenuItem>().Title($"[green]{Title}[/]");

        selectionPrompt.AddChoices(SelectionItems);

        var backSelectionOption = IsMainMenu ? ConsoleSelectionMenuItem.ExitItem : ConsoleSelectionMenuItem.BackItem;
        selectionPrompt.AddChoice(backSelectionOption);

        var selected = AnsiConsole.Prompt(selectionPrompt);

        if (selected.IsExit)
        {
            OnExit();
            return;
        }

        OnBeforeSelectionInvoke(selected);
        InvokeSelection(selected);
        OnSelection(selected);
        OnAfterSelectionInvoked(selected);

        Render();
    }

    public virtual void OnBeforeSelectionInvoke(ConsoleSelectionMenuItem selection)
    {
    }

    public virtual void InvokeSelection(ConsoleSelectionMenuItem selection)
    {
        selection.Action?.Invoke();
    }

    public virtual void OnSelection(ConsoleSelectionMenuItem selection)
    {
    }

    public virtual void OnAfterSelectionInvoked(ConsoleSelectionMenuItem selection)
    {
        if (selection.PauseOnComplete)
        {
            AnsiConsole.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }

    public virtual void OnExit()
    {
    }
}
