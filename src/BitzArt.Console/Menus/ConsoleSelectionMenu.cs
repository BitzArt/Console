using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleSelectionMenu : ConsoleMenu
{
    protected virtual List<ConsoleSelectionMenuItem> SelectionItems { get; set; } = [];
    private bool _exiting = false;

    public void AddSubmenu<TMenu>(string? selectionName = null)
        where TMenu : class
    {
        selectionName ??= typeof(TMenu).Name;
        AddSelection(selectionName, async () => await RunAsync<TMenu>());
    }

    public void AddSelection(string name, Action? action = null, bool pauseOnComplete = false)
    {
        SelectionItems.Add(new ConsoleSelectionMenuItem(name, action, pauseOnComplete));
    }

    internal override void Render()
    {
        while(true)
        {
            if (_exiting) break;
            base.Render();
        }
    }

    internal override void Display()
    {
        var selectionPrompt = new SelectionPrompt<ConsoleSelectionMenuItem>();

        selectionPrompt.AddChoices(SelectionItems);

        var backSelectionOption = IsMainMenu!.Value ? ConsoleSelectionMenuItem.ExitItem : ConsoleSelectionMenuItem.BackItem;
        selectionPrompt.AddChoice(backSelectionOption);

        var selected = selectionPrompt.Show(AnsiConsole.Console);

        if (selected.IsExit)
        {
            _exiting = true;
            OnExit();
            return;
        }

        OnSelectionBeforeInvoke(selected);
        InvokeSelection(selected);
        OnSelection(selected);
        AfterSelectionInvoked(selected);
    }

    protected virtual void OnSelectionBeforeInvoke(ConsoleSelectionMenuItem selection)
    {
    }

    internal virtual void InvokeSelection(ConsoleSelectionMenuItem selection)
    {
        selection.Action?.Invoke();
    }

    protected virtual void OnSelection(ConsoleSelectionMenuItem selection)
    {
    }

    internal virtual void AfterSelectionInvoked(ConsoleSelectionMenuItem selection)
    {
        if (selection.PauseOnComplete) Pause();
    }

    protected static void Pause()
    {
        AnsiConsole.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }

    protected virtual void OnExit()
    {
    }
}
