using Spectre.Console;

namespace BitzArt.Console;

public abstract class ConsolePanelMenuBase(Panel panel) : ConsoleMenuBase
{
    public Panel Panel { get; set; } = panel;
}
