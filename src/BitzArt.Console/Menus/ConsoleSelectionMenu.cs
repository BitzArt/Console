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

    protected override void Render()
    {
        while(true)
        {
            if (_exiting) break;
            base.Render();
        }
    }

    protected override void Display()
    {
        var selectionPrompt = new SelectionPrompt<ConsoleSelectionMenuItem>().Title($"[green]{Title}[/]");

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

        OnBeforeSelectionInvoke(selected);
        InvokeSelection(selected);
        OnSelection(selected);
        OnAfterSelectionInvoked(selected);
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
        if (selection.PauseOnComplete) Pause();
    }

    protected static void Pause()
    {
        AnsiConsole.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }

    public virtual void OnExit()
    {
    }
}
