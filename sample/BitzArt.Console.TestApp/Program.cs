namespace BitzArt.Console;

internal class Program
{
    static void Main()
    {
        var builder = new ConsoleAppBuilder();

        builder.Services.AddConsoleMenusFromAssemblyContaining<Program>();

        var app = builder.Build();

        app.Run<MainMenu>();
    }
}
