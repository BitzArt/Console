using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsoleSelectionMenuBase(Panel panel) : ConsolePanelMenuBase(panel)
{
    protected virtual bool IsMain => false;

    public override string Title => "Selection Menu";

    protected virtual List<ConsoleSelectionMenuItem> Items { get; set; } = [];
}
